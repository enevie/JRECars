$(function () {
    var showedImage = $('#detailed-pic-container-pic-0');
   
    showedImage.css("display", "block");

    var allImages = $("img[id^=detailed-pic-container-pic-]");
    var rightArrow = $('#right-arrow-pic-slider');


    rightArrow.on("click", function () {
        showedImage.attr("src", allImages.next().attr("src"));
        if (allImages.index(allImages.next()) + 1 == allImages.size()) {
            var firstImage = allImages[0];
            showedImage.attr("src", firstImage.attr('src'));
        }
    });


});