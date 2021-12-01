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
        nextArrow: `<i class="fal fa-chevron-right iconright"></i>`,
        prevArrow: `<i class="fal fa-chevron-left iconleft"></i>`,
        respondTo: 'window',


    });


});