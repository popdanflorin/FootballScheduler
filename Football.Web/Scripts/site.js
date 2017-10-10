$(document).ready(function () {

    $("#StartLeagueBtn").click(function (event) {
        debugger;
        var leagueTypeId = $("#selectLeague option:selected").attr("id");
        console.log("league = " + leagueTypeId);
        $("#StartLeagueBtn").removeClass("active");
        var data = {
            leagueTypeId: leagueTypeId,
        };
        $.ajax({
            url: "/Home/StartLeague",
            data: JSON.stringify(data),
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            cache: false,
            async: true,
            error: function (jqXHR, error, errorThrown) {
                //display error
            },
            success: function (data, textStatus, jqXHR) {
                $("body").html(data);
            }
        })
    });
    $("#playRound").click(function (event) {
        var leagueId = $("#playRound").attr("data-id");
        var data = {
            leagueId: leagueId,
        };
        $.ajax({
            url: "/Home/PlayRound",
            data: JSON.stringify(data),
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            cache: false,
            async: true,
            error: function (jqXHR, error, errorThrown) {
                //display error
            },
            success: function (data, textStatus, jqXHR) {
                debugger;
                $("body").html(data);
            }
        })
    });
    //$("#viewScores").click(function (event) {
    //    var leagueId = $("#viewScores").attr("data-id");
    //    var data = {

    //    };
    //    $.ajax({
    //        url: "/Home/ViewScores",
    //        data: JSON.stringify(data),
    //        type: "POST",
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "html",
    //        cache: false,
    //        async: true,
    //        error: function (jqXHR, error, errorThrown) {
    //            //display error
    //        },
    //        success: function (data, textStatus, jqXHR) {
    //            debugger;
    //            $("body").html(data);
    //        }
    //    })
  //  })

   
});