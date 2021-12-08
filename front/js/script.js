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
        if (position > 400) {
            document.getElementById("navmenu").classList.add("stickynavbar");

        } else {
            document.getElementById("navmenu").classList.remove("stickynavbar");
        }

        if (position > 50) {
            document.getElementById("cart").innerHTML = ' <a href=""><img src="img/icons/cart.png" alt=""> <p> Səbət </p> </a>';
        } else {
            document.getElementById("cart").innerHTML = '';
        }
        if (position > 50) {
            document.getElementById("domino").innerHTML = ' <a href=""><img class="domino" src="img/icons/single_domino.png" alt=""></a>';
        } else {
            document.getElementById("domino").innerHTML = '';
        }
    });
    // let loader = document.getElementById("loader");
    // window.addEventListener("load", function() {

    //     loader.style.visibilty = "visible";

    // })
    function hideLoader() {
        $('#loader').hide();
    }

    $(window).ready(hideLoader);

    // Strongly recommended: Hide loader after 20 seconds, even if the page hasn't finished loading
    setTimeout(hideLoader, 20 * 1000);


    // document.addEventListener("scroll", () => {
    //     const element = Array.from(document.querySelectorAll(":hover"))[4];
    //     console.log(element.id);
    // })
});