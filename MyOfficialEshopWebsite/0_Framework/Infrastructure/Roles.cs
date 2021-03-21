using System.Collections.Generic;

namespace _0_Framework.Infrastructure
{
    public static class Roles
    {
        public const string Administrator = "1";
        public const string ContentUploader = "2";
        public const string UserSystem = "3";
        public const string AdminAssistant = "4";
        public const string ColleagueUser = "5";

        public static string GetRoleBy(long id)
        {
            return id switch
            {
                1 => "مدیر سیستم",
                2 => "محتوا گذار",
                4 => "دستیار مدیر",
                _ => ""
            };
        }

        

    }
}
