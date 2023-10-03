    var imagesSrc = [];
    $(".account-upload").each(function () {
            var indx = $(".account-upload").index($(this));
    imagesSrc[indx] = $(".account-upload-img").eq(indx).attr("src") == undefined
    || $(".account-upload-img").eq(indx).attr("src") == "" ? "" : $(".account-upload-img").eq(indx).attr("src");

    $(this).on('change', function (t) {
                var n = new FileReader, c = t.target.files;
    n.onload = function () {
        $(".account-upload-img").eq(indx)
        && $(".account-upload-img").eq(indx).attr("src", n.result)
    },
    n.readAsDataURL(c[0]);

            });
        });
    $(".account-reset").each(function (indx) {
            var indx = $(".account-reset").index($(this));
    $(this).on('click', function () {
        $(".account-upload-img").eq(indx).attr("src", imagesSrc[indx]);
            });
        });

