$(function () {
    var skiprow = 0;
    $(document).on('click', '#loadMore', function () {
        $.ajax({
            method: "GET",
            url: "Pricing/LoadMore",
            data: {
                skiprow:skiprow
            },
            success: function (result) {
                $('#ourpricings').append(result)
                skiprow++;
            }
        })
    })
})