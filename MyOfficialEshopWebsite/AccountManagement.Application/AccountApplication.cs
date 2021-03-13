using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.Role;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAccountRepository _accountRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IAuthHelper _authHelper;
        private readonly IRoleRepository _roleRepository;

        public AccountApplication(IAccountRepository accountRepository, IPasswordHasher passwordHasher,
            IFileUploader fileUploader, IAuthHelper authHelper, IRoleRepository roleRepository)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _fileUploader = fileUploader;
            _authHelper = authHelper;
            _roleRepository = roleRepository;
        }

        public OperationResult Register(RegisterAccount command)
        {
            var operation = new OperationResult();

            if (_accountRepository.Exist(x => x.Username == command.Username || x.Mobile == command.Mobile))
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            var picturePath = $"ProfilePhotos";
            var photoName = _fileUploader.Upload(command.ProfilePhoto, picturePath);

            var password = _passwordHasher.Hash(command.Password);

            var account = new Account(command.FullName, command.Username, password, command.RoleId, command.Mobile, photoName);

            _accountRepository.Create(account);
            _accountRepository.SaveChanges();

            return operation.Succedded();

        }

        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }
            if (_accountRepository.Exist(x => x.Username == command.Username || x.Mobile == command.Mobile && x.Id != command.Id))
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var picturePath = $"ProfilePhotos";
            var photoName = _fileUploader.Upload(command.ProfilePhoto, picturePath);

            account.Edit(command.FullName, command.Username, command.RoleId, command.Mobile, photoName);

            _accountRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }
            if (command.Password != command.RePassword)
            {
                return operation.Failed(ApplicationMessages.DuplicatedPassword);
            }

            var password = _passwordHasher.Hash(command.Password);
            account.ChangePassword(password);

            _accountRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Login(Login command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetBy(command.Username);

            if (account == null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }

            (bool Verified, bool NeedsUpgrade) result = _passwordHasher.Check(account.Password, command.Password);

            if (!result.Verified)
            {
                return operation.Failed(ApplicationMessages.WrongUserPass);
            }

            //var permissions = _roleRepository
            //    .Get(account.RoleId)
            //    .Permissions
            //    .Select(x => x.Code)
            //    .ToList();

            var authViewModel = new AuthViewModel(account.Id, account.RoleId, account.FullName,
                account.Username, account.ProfilePhoto/*, permissions*/);

            _authHelper.SignIn(authViewModel);

            return operation.Succedded();
        }

        public EditAccount GetDetails(long id)
        {
            return _accountRepository.GetDetails(id);
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _accountRepository.Search(searchModel);
        }

        public List<AccountViewModel> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Logout()
        {
            _authHelper.SignOut();
        }
    }
}
