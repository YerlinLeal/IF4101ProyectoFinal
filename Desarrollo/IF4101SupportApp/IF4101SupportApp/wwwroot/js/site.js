var $th = $('.scroll-vertical').find('thead th')
$('.scroll-vertical').on('scroll', function () {
    $th.css('transform', 'translateY(' + this.scrollTop + 'px)');
});

$(function () {
    LoadTable();
});

function LoadTable() {
    var form = $('#form-issue-details');
    form.find("#btnUSO").hide();
    form.find("#btnSaveClassification").hide();
    var role = form.find("#role").val();
    var id = form.find("#id").val();
    var apiUrl = "";
    if (role == 2) {
        apiUrl = "/Issue/GetIssuesByIdUser";
    } else {
        apiUrl = "/Issue/GetAll";
    }

    $('#table-recorded-issues').DataTable({
        "destroy": true,
        ajax: {
            url: apiUrl,
            dataSrc: '',
        },
        columns: [
            {
                "render": function (data, type, s, meta) {
                    return '<button class="hvr-bounce-in" data-toggle="modal" data-target="#IssueDetailsModal" onclick="LoadIssue(' + s.reportNumber + ')"><i class="fa fa-eye" aria-hidden="true"></i></div></td ></button >'
                }
            },
            { data: 'reportNumber' },
            {
                "render": function (data, type, s, meta) {
                    if (s.employeeName == null) {
                        return "Not assigned";
                    } else {
                        return s.employeeName + ' ' + s.firstSurname;
                    }
                }
            },
            {
                "render": function (data, type, s, meta) {
                    if (s.classification == 'A') {
                        return 'High'
                    } else if (s.classification == 'M') {
                        return 'Half'
                    } else if (s.classification == 'B') {
                        return 'Low'
                    } else {
                        return ''
                    }
                }
            },
            {
                "render": function (data, type, s, meta) {
                    if (s.status == 'I') {
                        return 'Inserted'
                    } else if (s.status == 'A') {
                        return 'Assigned'
                    } else if (s.status == 'P') {
                        return 'In progress'
                    } else if (s.status == 'R') {
                        return 'Resolved'
                    } else {
                        return ''
                    }
                }
            },
            { data: 'creationDate' },
            { data: 'reportTimestamp' }
        ]
    });

}

function LoadIssue(reportNumber) {
    $("#message-alert-issue").hide();

    $.ajax({
        url: "/Issue/GetIssue",
        data: { "reportNumber": reportNumber },
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (issue) {
            var form = $('#form-issue-details');
            form.find("#reportNumberIssue").val(issue.reportNumber);
            form.find("#userIssue").val("BD client");
            form.find("#emailIssue").val("BD client");
            form.find("#phoneIssue").val("BD client");
            form.find("#addressIssue").val("BD client");
            form.find("#secondContactIssue").val("BD client");
            form.find("#statusIssue").val(issue.status);
            form.find("#classificationIssue").val(issue.classification);
            form.find("#contactEmailIssue").val("BD client");
            form.find("#contactPhoneIssue").val("BD client");
            form.find("#commentsIssue").val(issue.resolutionComment);

            sessionStorage.setItem('ReportNumber', issue.reportNumber);
            var selectSupporters = form.find("#supportUserAssignedIssue");

            var role = form.find("#role").val();
            var id = form.find("#id").val();
            $('#IssueInfoTabs li:first-child a').tab('show');
            if (issue.employeeAssigned == id) {
                $('#buttonEditFinalComment').removeClass('hide');
            } else {
                $('#buttonEditFinalComment').addClass('hide');
            }
            if (role == 1 && (issue.employeeAssigned == null || issue.supervised == id)) {
                $.ajax({
                    url: "/Issue/GetSupportersById",
                    data: { "id": id },
                    type: "GET",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (supporters) {
                        form.find("#btnUSO").show();
                        form.find("#btnSaveClassification").show();
                        selectSupporters.find('option').remove();
                        for (i in supporters) {
                            if (supporters[i].employeeId == issue.employeeAssigned) {
                                selectSupporters.append('<option selected value="' + supporters[i].employeeId + '">' + supporters[i].employeeName + ' ' + supporters[i].firstSurname + '</option>');
                            } else {
                                selectSupporters.append('<option value="' + supporters[i].employeeId + '">' + supporters[i].employeeName + ' ' + supporters[i].firstSurname + '</option>');
                            }
                        }
                    },
                    error: function (error) {

                    }
                });
                StatusButton();
                StatusSelectSuporters()
            } else {
                
                $("#supportUserAssignedIssue").prop("disabled", true);
                form.find("#classificationIssue").attr("disabled", "disabled");
                selectSupporters.append('<option selected value="' + issue.employeeAssigned + '">' + issue.employeeName + ' ' + issue.firstSurname + '</option>');
                StatusButton();
            }
            
        },
        error: function (errorMessage) {
            console.log("Error");
        }
    });

}

function StatusSelectSuporters() {
    var form = $('#form-issue-details');
    if (form.find("#statusIssue").val() == 'A') {

        $("#supportUserAssignedIssue").prop("disabled", false);

    } else if (form.find("#statusIssue").val() == 'P') {

        $("#supportUserAssignedIssue").prop("disabled", false);

    } else if (form.find("#statusIssue").val() == 'R') {

        $("#supportUserAssignedIssue").prop("disabled", true);

    } else if (form.find("#statusIssue").val() == 'I') {

        $("#supportUserAssignedIssue").prop("disabled", false);

    }
}

function StatusButton() {
    $("#btn-status-issue").off();

    var form = $('#form-issue-details');
    if (form.find("#statusIssue").val() == 'A') {
        $("#btn-status-issue").show();
        $("#btn-status-issue").html("Start Process");
        $("#btn-status-issue").click({ status: "P" }, SetIssueStatus);
        $("#btn-status-issue").prop("disabled", false);
    } else if (form.find("#statusIssue").val() == 'P') {
        $("#btn-status-issue").show();
        $("#btn-status-issue").html("Resolve");
        
        $("#btn-status-issue").click({ status: "R" }, SetIssueStatus);
        $("#btn-status-issue").prop("disabled", false);
    } else if (form.find("#statusIssue").val() == 'R') {
        $("#btn-status-issue").show();
        $("#btn-status-issue").html("Resolved");
        $("#btn-status-issue").prop("disabled", true);
    } else if (form.find("#statusIssue").val() == 'I') {
        $("#btn-status-issue").hide();
    }
}

function AssignSupporter() {
    var form = $('#form-issue-details');
    var id = form.find("#id").val();

    $.ajax({
        url: "/Issue/PutIssue",
        data: {
            ReportNumber: $("#reportNumberIssue").val(),
            Classification: $("#classificationIssue").val(),
            EmployeeAssigned: $("#supportUserAssignedIssue").val(),
            ModifiedBy: id,
            Status: "A"
        },
        type: "PUT",
        dataType: "json",
        
        success: function (result) {
            LoadTable();
            $("#IssueDetailsModal").modal("hide");
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}

function SetIssueStatus(event) {
    var status = event.data.status;
    var form = $("#form-issue-details");
    var comment = $("#commentsIssue").val();
    var id = form.find("#id").val();
    if (status == 'R') {
        if (comment != "") {
            var assigned = $("#supportUserAssignedIssue").val();
            if (assigned == id) {
                $.ajax({
                    url: "/Issue/PutIssue",
                    data: {
                        ReportNumber: $("#reportNumberIssue").val(),
                        Classification: $("#classificationIssue").val(),
                        EmployeeAssigned: $("#supportUserAssignedIssue").val(),
                        ModifiedBy: id,
                        Status: status,
                        ResolutionComment: comment
                    },
                    type: "PUT",
                    dataType: "json",

                    success: function (result) {
                        LoadTable();
                        $("#IssueDetailsModal").modal("hide");
                    },
                    error: function (errorMessage) {
                        alert(errorMessage.responseText);
                    }
                });
            }
        } else {
            $("#message-alert-issue").html("Please enter a comment before finalizing");
            $("#message-alert-issue").show();
        }
    } else {
        var assigned = $("#supportUserAssignedIssue").val();
        if (assigned == id) {
            $.ajax({
                url: "/Issue/PutIssue",
                data: {
                    ReportNumber: $("#reportNumberIssue").val(),
                    Classification: $("#classificationIssue").val(),
                    EmployeeAssigned: $("#supportUserAssignedIssue").val(),
                    ModifiedBy: id,
                    Status: status,
                    ResolutionComment: comment
                },
                type: "PUT",
                dataType: "json",

                success: function (result) {
                    LoadTable();
                    $("#IssueDetailsModal").modal("hide");
                },
                error: function (errorMessage) {
                    alert(errorMessage.responseText);
                }
            });
        }
    }
    
}

function ChangeClassification() {
    var form = $('#form-issue-details');
    var id = form.find("#id").val();

    $.ajax({
        url: "/Issue/PutIssue",
        data: {
            ReportNumber: $("#reportNumberIssue").val(),
            Classification: $("#classificationIssue").val(),
            EmployeeAssigned: $("#supportUserAssignedIssue").val(),
            ModifiedBy: id,
            Status: $("#statusIssue").val()
        },
        type: "PUT",
        dataType: "json",

        success: function (result) {
            LoadTable();
            $("#IssueDetailsModal").modal("hide");
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}

function EditFinalComment() {
    $("#commentsIssue").prop("disabled", false);
    $("#buttonSaveFinalComment").removeClass("hide");
}

function SaveFinalComment() {
    var form = $("#form-issue-details");
    var id = form.find("#id").val();
    var assigned = $("#supportUserAssignedIssue").val();
    if (assigned == id) {
        $.ajax({
            url: "/Issue/PutIssue",
            data: {
                ReportNumber: $("#reportNumberIssue").val(),
                Classification: $("#classificationIssue").val(),
                EmployeeAssigned: $("#supportUserAssignedIssue").val(),
                ModifiedBy: id,
                Status: $("#statusIssue"),
                ResolutionComment: $("#commentsIssue").val()
            },
            type: "PUT",
            dataType: "json",
            success: function (result) {
                $("#commentsIssue").prop("disabled", true);
                $("#buttonSaveFinalComment").addClass("hide");
            },
            error: function (errorMessage) {
                alert(errorMessage.responseText);
            }
        });
    }
}