
const cookieName = "cart-items";
const cookieWishlist = "wishlist-items";


function addToCart(id, name, price, picture) {
    let products = $.cookie(cookieName);
    if (products === undefined) {
        products = [];
    } else {
        products = JSON.parse(products);
    }

    const count = $("#productCount").val();
    const currentProduct = products.find(x => x.id === id);

    if (currentProduct !== undefined) {
        products.find(x => x.id === id).count = parseInt(currentProduct.count) + parseInt(count);
    } else {
        const product = {
            id,
            name,
            unitPrice: price,
            picture,
            count
        }
        products.push(product);
    }
    $.cookie(cookieName, JSON.stringify(products), { expires: 7, path: "/" });
    updateCart();
}

function updateCart() {
    let products = $.cookie(cookieName);
    products = JSON.parse(products);
    $("#cart_items_count").text(products.length);
    $("#cart_items_count_mobile").text(products.length);
    const cartItemsWrapper = $("#mini_cart_inner");
    const cartItemsWrapperMobile = $("#mini_cart_inner_mobile");

    if (products.length === 0) {
        cartItemsWrapper.html('سبد خرید شما خالی می باشد');
        cartItemsWrapperMobile.html('سبد خرید شما خالی می باشد');
    }

    products.forEach(x => {
        const product = `<div class="cart_item">
                                        <div class="cart_img">
                                            <a href="#"><img src="/Pictures/${x.picture}" alt="${x.name}" title="${x.name}"></a>
                                        </div>
                                        <div class="cart_info">
                                            <a href="#">${x.name}</a>
                                            <p>
                                                تعداد: ${x.count} ×
                                                <span> ${x.unitPrice} تومان </span>
                                            </p>
                                            <p>
                                                جمع اجزا: 
                                                <span> ${(parseInt(x.unitPrice) * x.count)} تومان </span>
                                            </p>
                                        </div>
                                        <div class="cart_remove" onclick="removeFromCart('${x.id}')">
                                            <a href="#"><i class="ion-android-close"></i></a>
                                        </div>
                                    </div>
                                </div>`;


        cartItemsWrapper.append(product);
        cartItemsWrapperMobile.append(product);
    });


}

function removeFromCart(id) {
    let products = $.cookie(cookieName);
    products = JSON.parse(products);
    const itemToRemove = products.findIndex(x => x.id === id);
    products.splice(itemToRemove, 1);
    $.cookie(cookieName, JSON.stringify(products), { expires: 7, path: "/" });

    location.reload();
    updateCart();


}

function changeCartItemCount(id, totalId, count) {
    var products = $.cookie(cookieName);
    products = JSON.parse(products);
    const productIndex = products.findIndex(x => x.id == id);
    products[productIndex].count = count;
    const product = products[productIndex];
    const newPrice = parseInt(product.unitPrice) * parseInt(count);
    $(`#${totalId}`).text(newPrice);
    //products[productIndex].totalprice = newPrice;
    $.cookie(cookieName, JSON.stringify(products), { expires: 7, path: "/" });

    updateCart();




}

/////////////////////////////////////////////////////////////////////////////////////////////

function addToWishlist(id, name, price, picture) {
    debugger;
    let wishlists = $.cookie(cookieWishlist);
    if (wishlists === undefined) {
        wishlists = [];
    } else {
        wishlists = JSON.parse(wishlists);
    }

    var count = 1;
    const currentWishlist = wishlists.find(x => x.id === id);

    if (currentWishlist !== undefined) {
        wishlists.find(x => x.id === id).count = parseInt(currentWishlist.count) + (count);
    } else {
        const wishlist = {
            id,
            name,
            unitPrice: price,
            picture,
            count
        }
        wishlists.push(wishlist);
    }


    $.cookie(cookieWishlist, JSON.stringify(wishlists), { expires: 60, path: "/" });
    updateWishlist();

}

function updateWishlist() {

    let wishlists = $.cookie(cookieWishlist);
    wishlists = JSON.parse(wishlists);
    const count = $("#wishlist_count").text(wishlists.length);

    const currentWishlist = wishlists.find(x => x.id === id);
    if (currentWishlist !== undefined) {
        wishlists.find(x => x.id === id).count = parseInt(currentWishlist.count) + parseInt(count);
    } else {
        const wishlist = {
            id,
            name,
            unitPrice: price,
            picture,
            count
        }

        wishlists.push(wishlist);

    }


}

function removeFromWishlist(id) {
    let wishlists = $.cookie(cookieWishlist);
    wishlists = JSON.parse(wishlists);
    const itemToRemove = wishlists.findIndex(x => x.id === id);
    wishlists.splice(itemToRemove, 1);
    $.cookie(cookieWishlist, JSON.stringify(wishlists), { expires: 60, path: "/" });

    location.reload();
    updateWishlist();


}
