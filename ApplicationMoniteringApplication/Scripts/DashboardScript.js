$(document).ready(function () {

    $('.star').on('click', function () {
        $(this).toggleClass('star-checked');
    });

    $('.ckbox label').on('click', function () {
        $(this).parents('tr').toggleClass('selected');
    });

    $('.btn-filter').on('click', function () {
        var $target = $(this).data('target');
        if ($target != 'all') {
            $('.table tr').css('display', 'none');
            $('.table tr[data-status="' + $target + '"]').fadeIn('slow');
        } else {
            $('.table tr').css('display', 'none').fadeIn('slow');
        }
    });

    $(function () {
        LoadData();
        $("#btnSave").click(function () {
            //alert("");  
            var req = {};
            req.Duration = $(Duration).val();
            req.Category = $(Category).val();
            $.ajax({
                type: "GET",
                url: '@Url.Action("HomeController/GetFilteredData")',
                data: '{std: ' + JSON.stringify(req) + '}',
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function () {
                    // alert("Data has been added successfully.");  
                    //LoadData();
                },
                error: function () {
                    alert("Error while inserting data");
                }
            });
            return false;
        });
    });

});