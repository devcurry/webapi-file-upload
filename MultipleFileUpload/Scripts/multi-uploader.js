/// <reference path="jquery-1.8.2.js" />
/// <reference path="_references.js" />
$(document).ready(function ()
{
    $(document).on("click", "#fileUpload", beginUpload);
});

function beginUpload(evt)
{
    var files = $("#selectFile").get(0).files;
    if (files.length > 0)
    {
        if (window.FormData !== undefined)
        {
            var data = new FormData();
            for (i = 0; i < files.length; i++)
            {
                data.append("file" + i, files[i]);
            }
            $.ajax({
                type: "POST",
                url: "/api/upload",
                contentType: false,
                processData: false,
                data: data,
                success: function (results)
                {
                    for (i = 0; i < results.length; i++)
                    {
                        alert(results[i]);
                    }
                }
            });
        } else
        {
            alert("This browser doesn't support HTML5 multiple file uploads!");
        }
    }
}