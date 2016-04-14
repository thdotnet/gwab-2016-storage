$(function () {
    $("a.image").each(function (item) {
        var a = $(this);

        a.click(function () {
            var ok = window.confirm("Redimencionar?");

            if (ok == false) return;
            var link = $(this);
            var name = link.data("name");

            var url = document.location.protocol + "//" + document.location.host + "/Home/Resize";

            $.post(url, { name: name }, function (result) {
                if (result)
                {
                    document.location.reload();
                }
            });
        });
    })
});