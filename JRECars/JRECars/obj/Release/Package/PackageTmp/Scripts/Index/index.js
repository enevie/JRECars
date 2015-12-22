$(function () {
    var initiatePictures = function (images, containers) {

        if (images.length > 0 && containers.length > 0) {
            var randomCars = (Math.floor(Math.random() * images.length));
            var randomContainers = (Math.floor(Math.random() * containers.length));

            var currentImage = images[randomCars];
            var currentContainer = containers[randomContainers];
            var currentContainerImages = [];
            $.each(containers, function () {
                currentContainerImages.push($(this).children().attr('src'));
            });

            while (true) {
                randomCars = (Math.floor(Math.random() * images.length));
                if ($.inArray(currentImage, currentContainerImages) !== -1) {
                    currentImage = images[randomCars];
                } else {
                    break;
                }
            }

            currentContainer.children().fadeOut("normal",function() {
                $(this).hide();
                currentContainer.children().attr('src', currentImage);
                currentContainer.children().fadeIn(1500);
            });
        }
    }

    var pushPictures = function () {
        var images = [];

        var picOne = $('#front-image-1').attr('src');
        var picTwo = $('#front-image-2').attr('src');
        var picThree = $('#front-image-3').attr('src');
        var picFour = $('#front-image-4').attr('src');
        var picFive = $('#front-image-5').attr('src');
        var picSix = $('#front-image-6').attr('src');
        var picSeven = $('#front-image-7').attr('src');
        var picEigth = $('#front-image-8').attr('src');

        if (picOne.length) {
            images.push(picOne);
        }
        if (picTwo.length) {
            images.push(picTwo);
        }
        if (picThree.length) {
            images.push(picThree);
        }
        if (picFour.length) {
            images.push(picFour);
        }
        if (picFive.length) {
            images.push(picFive);
        }
        if (picSix.length) {
            images.push(picSix);
        }
        if (picSeven.length) {
            images.push(picSeven);
        }
        if (picEigth.length) {
            images.push(picEigth);
        }

        return images;
    }

    var initiateContainers = function () {
        var containers = [];

        //containers
        var firstContainer = $('#conteiner-pic-1');
        var secondContainer = $('#conteiner-pic-2');
        var thirdContainer = $('#conteiner-pic-3');
        var fourthContainer = $('#conteiner-pic-4');

        if (firstContainer.length) {
            containers.push(firstContainer);
        }
        if (secondContainer.length) {
            containers.push(secondContainer);
        }

        if (thirdContainer.length) {
            containers.push(thirdContainer);
        }
        if (fourthContainer.length) {
            containers.push(fourthContainer);
        }

        return containers;
    }

    setInterval(function() {
        initiatePictures(pushPictures(), initiateContainers());
    }, 2000);
    
});

