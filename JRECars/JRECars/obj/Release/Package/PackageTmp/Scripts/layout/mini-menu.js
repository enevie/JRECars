$(function () {
    var oddClick = true;
    var switchArrows = true;
    var containerMenuOne = $('#container-menu-1');
    var containerMenuTwo = $('#container-menu-2');
    var containerMenuThree = $('#container-menu-3');

    var showContainerOne = function () {
        jQuery(containerMenuOne).toggle("slide", { direction: "left" }, 500);
    };

    var showContainerTwo = function () {
        jQuery(containerMenuTwo).toggle("slide", { direction: "left" }, 500);
    };

    var showContainerThree = function () {
        jQuery(containerMenuThree).toggle("slide", { direction: "left" }, 500);
    };

    var menuShow = function () {
        $('#mini-menu').animate({
            width: switchArrows ? 150 : 40
        }, 250);
        switchArrows = !switchArrows;
    };

    $('#mini-menu #arrow').click(function () {
        if (oddClick) {
            menuShow();
            setTimeout(showContainerOne, 400);
            setTimeout(showContainerTwo, 600);
            setTimeout(showContainerThree, 800);
        } else {
            setTimeout(showContainerThree, 100);
            setTimeout(showContainerTwo, 200);
            setTimeout(showContainerOne, 300);
            setTimeout(menuShow, 800);
        }
        oddClick = !oddClick;
    });

    $('#mini-menu').on("click", function () {
        if (!oddClick) {
            $('#arrow').attr('src', '../../Content/images/left-arrow.png');
        } else {
            $('#arrow').attr('src', '../../Content/images/right-arrow-icon.png');
        }
    });
});