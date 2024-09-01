var page = 0,
    inCallback = false,
    isReachedScrollEnd = false;

var scrollHandler = function () {
    if (isReachedScrollEnd == false &&
        ($(document).scrollTop() <= $(document).height() - $(window).height()))
    {
        loadProjectData(url);
    }
}

function loadProjectData(loadMoreRowsUrl) {
    if (page > -1 && !inCallback) {
        inCallback = true;
        page++;
        $("div#loading").show();

        $.ajax({
            type: 'GET',
            url: loadMoreRowsUrl,
            data: "pageNum=" + page,
            success: function (data, textstatus) {
                if (data != '') {
                    $("table.mytable > tbody").append(data);
                    $("table.mytable > tbody > tr:even").addClass("alt-row-class");
                    $("table.mytable > tbody > tr:odd").removeClass("alt-row-class");
                }
                else {
                    page = -1;
                }

                inCallback = false;
                $("div#loading").hide();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
    }
}