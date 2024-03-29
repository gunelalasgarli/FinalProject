$(document).ready(function() {
    $('#search-input').keyup(function() {

        let search = $(this).val().trim();
        if (search.length === 0) {}
        $.ajax({
            url: `Product/Search?search=${search}`,
            method: 'GET',
            success: function(resp) {
                $('#dataTable').html(resp);
                console.log(resp);
            }
        })
    })

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

    function hideLoader() {
        $('#loader').hide();
    }

    $(window).ready(hideLoader);
    setTimeout(hideLoader, 20 * 1000);

    $(window).scroll(function(e) {
        let position = $(this).scrollTop();
        if (!$('body').is('.Account')) {

            if ($('body').is('.Home')) {
                if (position > 415) {
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
            //let updateCartBadge = (count) => {
            //    let cart = document.querySelector("header .navbar-item .side-icons .cart .basket");
            //    cart.innerHTML = count;
            //}
            //if (window.localStorage.getItem("basket") != null) {
            //    let cartCount = window.localStorage.getItem("basket").split(",").length;
            //    updateCartBadge(cartCount);

            //}

            //let addToCart = (prdId) => {
            //    let cart = window.localStorage.getItem("basket");
            //    let currentValue;
            //    if (cart == null || cart == "") {
            //        currentValue = prdId;
            //        window.localStorage.setItem("basket", currentValue);
            //        updateCartBadge(1);
            //    } else {
            //        let IdList = cart.split(",");
            //        let isExist = false;
            //        for (let j = 0; j < IdList.length; j++) {
            //            if (IdList[j] == prdId) {
            //                isExist = true;
            //            }
            //        }
            //        if (!isExist) {
            //            currentValue = cart + "," + prdId;
            //            window.localStorage.setItem("basket", currentValue);
            //            updateCartBadge(IdList.length + 1);
            //        }
            //    }
            //}

            //let addToCartBotton = document.getElementsByClassName("addToCart");
            //for (let i = 0; i < addToCartBotton.length; i++) {
            //    addToCartBotton[i].addEventListener("click", function(e) {
            //        e.preventDefault();
            //        let PrdId = this.dataset.id;
            //        addToCart(PrdId);
            //    });
            //}
        }
    });

    $('.pizza-item').on('click', function() {
        let url = $(this).parent().attr('href');
        fetch(url)
            .then(resp => resp.text())
            .then(data => {
                $('.modalHeader').html(data);
            })
    });

    // document.addEventListener("scroll", () => {
    //     const element = Array.from(document.querySelectorAll(":hover"))[4];
    //     console.log(element.id);
    // })
    // var firstScrollSpyEl = document.querySelector('[data-bs-spy="scroll"]')
    // var item = document.getElementsByClassName("nav-link")
    // firstScrollSpyEl.addEventListener('activate.bs.scrollspy', function() {
    //     console.log(item);
    // });

    //var url = document.querySelectorAll('.addToCart')[1].getAttribute('href');
    //var urlPart = url.slice(url.indexOf('count'), url.indexOf('count') + 7);
    //var quantitiy = 1;
    //$('.quantity-right-plus').click(function (e) {
    //    e.preventDefault();
    //    quantitiy++;
    //    $('#quantity').val(quantitiy);
    //    $('#total-price').text(`${(+quantitiy * +price).toFixed(2)}$`);
    //    url = url.replace(urlPart, `count=${quantitiy}`);
    //    console.log(url);
    //    document.querySelectorAll('.addToCart')[1].setAttribute('href', url);
    //});

    //$('.quantity-left-minus').click(function (e) {
    //    e.preventDefault();
    //    if (quantitiy > 1) {
    //        quantitiy--;
    //        $('#quantity').val(quantitiy);
    //        $('#total-price').text(`${(+quantitiy * +price).toFixed(2)}$`);
    //        url = url.replace(urlPart, `count=${quantitiy}`);
    //        document.querySelectorAll('.addToCart')[1].setAttribute('href', url);

    //    }
    //});
    var price = $('#total-price').text().slice(0, -1);
    var quantitiy = 1;
    var quantityValue = $("#quantity");
    $('.quantity-right-plus').click(function(e) {
        e.preventDefault();
        quantitiy++;
        $('#quantity').val(quantitiy);
        $('#total-price').text(`${(+quantitiy * +price).toFixed(2)}`);
        let url = document.querySelector('.addToCart').getAttribute('href');
        let urlPart = url.slice(url.indexOf('count'), url.indexOf('count') + 7);
        url = url.replace(urlPart, `count=${quantitiy}`);
        document.querySelector('.addToCart').setAttribute('href', url);
    });


    $('.quantity-left-minus').click(function(e) {
        e.preventDefault();
        if (quantitiy > 1) {
            quantitiy--;
            $('#quantity').val(quantitiy);
            $('#total-price').text(`${(+quantitiy * +price).toFixed(2)}`);
            let url = document.querySelector('.addToCart').getAttribute('href');
            let urlPart = url.slice(url.indexOf('count'), url.indexOf('count') + 7);
            url = url.replace(urlPart, `count=${quantitiy}`);
            document.querySelecto('.addToCart').setAttribute('href', url);
        }
    });

    document.querySelectorAll('.scrollable label').forEach((elem, index) => {

            elem.addEventListener('click', function() {
                quantityValue.val(1);
                quantitiy = 1;
                document.querySelector('#total-price').innerText = elem.querySelector('.price-size').innerText;
                let url = document.querySelector('.addToCart').getAttribute('href');
                let urlPart = url.slice(url.indexOf('size'), url.indexOf('size') + 6);
                url = url.replace(urlPart, `size=${index + 1}`);
                price = elem.querySelector('.price-size').innerText.slice(0, -1);
                console.log(document.querySelector('.addToCart'));
                document.querySelector('.addToCart').setAttribute('href', url);
            });

        })
        //$(document).on("click", ".add-basket", function (e) {
        //    e.preventDefault();

    //    var id = $(this).attr("data-id");

    //    fetch('https://localhost:5433/product/addtobasket/' + id)
    //        .then(response => response.text())
    //        .then(data => {

    //            $(".basket").html(data)
    //            var count = $("#favorite").data("favorite-count")
    //            $("#favorite-count").text(count)
    //        });
    //});

    //$(document).on("click", ".delete", function (e) {
    //    e.preventDefault();

    //    var id = $(this).attr("data-id");


    //    fetch('https://localhost:5433/product/deletefrombasket/' + id)
    //        .then(response => response.text())
    //        .then(data => {

    //            console.log(data);
    //            $(".basket").html(data)
    //            var count = $("#favorite").data("favorite-count")
    //            $("#favorite-count").text(count)
    //        });
    //})








});