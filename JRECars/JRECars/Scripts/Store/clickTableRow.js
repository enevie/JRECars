$(function() {
    $("#table .row-table:not(.header-row)").on('click', function () {
        var _this = $(this);
        window.location = _this.find("span.cell:last-child a:last-child").attr("href");
    });
});

