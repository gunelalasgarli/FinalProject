$(document).ready(function() {
    $('.slick-list').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 5000,
        speed: 400,
        draggable: false,
        infinite: true,
        cssEase: "ease",
        adaptiveHeight: false,
        arrows: true,
        nextArrow: `<i class="fal fa-chevron-right iconright slick-next"></i>`,
        prevArrow: `<i class="fal fa-chevron-left iconleft slick-prev"></i>`,
        respondTo: 'window'
    });

    $(window).scroll(function(e) {
        let position = $(this).scrollTop();
        if (!$('body').is('.Account')) {
            if ($('body').is('.Home')) {
                if (position > 400) {
                    document.getElementById("navmenu").classList.add("stickynavbar");

                } else {
                    document.getElementById("navmenu").classList.remove("stickynavbar");
                }
            } else {

                if (position > 100) {
                    document.getElementById("navmenu").classList.add("stickynavbar");

                } else {
                    document.getElementById("navmenu").classList.remove("stickynavbar");
                }



            }



            /* Cart */
            let updateCartBadge = (count) => {
                let cart = document.querySelector("header .navbar-item .side-icons .cart .basket");
                cart.innerHTML = count;
            }
            if (window.localStorage.getItem("basket") != null) {
                let cartCount = window.localStorage.getItem("basket").split(",").length;
                updateCartBadge(cartCount);

            }

            let addToCart = (prdId) => {
                let cart = window.localStorage.getItem("basket");
                let currentValue;
                if (cart == null || cart == "") {
                    currentValue = prdId;
                    window.localStorage.setItem("basket", currentValue);
                    updateCartBadge(1);
                } else {
                    let IdList = cart.split(",");
                    let isExist = false;
                    for (let j = 0; j < IdList.length; j++) {
                        if (IdList[j] == prdId) {
                            isExist = true;
                        }
                    }
                    if (!isExist) {
                        currentValue = cart + "," + prdId;
                        window.localStorage.setItem("basket", currentValue);
                        updateCartBadge(IdList.length + 1);
                    }
                }
            }

            let addToCartBotton = document.getElementsByClassName("addToCart");
            for (let i = 0; i < addToCartBotton.length; i++) {
                addToCartBotton[i].addEventListener("click", function(e) {
                    e.preventDefault();
                    let PrdId = this.dataset.id;
                    addToCart(PrdId);
                });
            }
        }
    });

    function hideLoader() {
        $('#loader').hide();
    }

    $(window).ready(hideLoader);
    setTimeout(hideLoader, 20 * 1000);


    // document.addEventListener("scroll", () => {
    //     const element = Array.from(document.querySelectorAll(":hover"))[4];
    //     console.log(element.id);
    // })
    // var firstScrollSpyEl = document.querySelector('[data-bs-spy="scroll"]')
    // var item = document.getElementsByClassName("nav-link")
    // firstScrollSpyEl.addEventListener('activate.bs.scrollspy', function() {
    //     console.log(item);
    // });


    var quantitiy = 0;
    $('.quantity-right-plus').click(function(e) {

        // Stop acting like a button
        e.preventDefault();
        // Get the field name
        var quantity = parseInt($('#quantity').val());

        // If is not undefined

        $('#quantity').val(quantity + 1);


    });


    $('.quantity-left-minus').click(function(e) {
        // Stop acting like a button
        e.preventDefault();
        // Get the field name
        var quantity = parseInt($('#quantity').val());

        // If is not undefined

        // Increment
        if (quantity > 0) {
            $('#quantity').val(quantity - 1);
        }


    });


});