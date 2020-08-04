$(document).ready(function () {
    //$("#js-doctor-parent").on("click", "#js-doctor-profiles", doctorprofile);
    //$("#js-doctor-parent").on("click", "#js-edit-doctor", editProfile);
    //$("#js-doc-editparent").on("click", "#js-savedocprofile", saveProfile);
    $("#js-doctor-parent").on("click", "#js-doctor-profiles", doctorprofile);
    $("#js-doctor-parent").on("click", "#js-doctor-patients", doctorpatients);
    $("#js-doctor-parent").on("click", "#js-doctor-appointments", doctorappointments);
    $("#js-doctor-parent").on("click", "#js-doctor-myschedule", doctorschedule);


    // doc profile
    $("#js-doctor-partial").on("click", "#js-edit-doctor", editProfile);
    $("#js-doctor-partial").on("click", "#js-savedocprofile", saveProfile);

    // patients
    $("#js-doctor-partial").on("click", "#js-addmorepatients", addmorepatients);
    $("#js-doctor-partial").on("click", "#js-save-new-patient", saveNewpatient);
    //$("#js-doctor-partial").on("click", "#js-edit-patient", editpatients);
    //$("#js-doctor-partial").on("click", "#js-delete-patient", deletepatients);
    //$("#js-doctor-partial").on("click", "#js-view-patient", viewpatientsdetails);

    //apointments
    $("#js-doctor-partial").on("click", "#js-add-moreappointments", addmoreappointments);
    $("#js-doctor-partial").on("click", "#js-save-new-appointment", savenewappointments);
    initappointment();


    //practice timmings
    $("#js-doctor-partial").on("click", "#js-doctor-createpractice", createpractice);

});

function createpractice() {
    debugger;
    var address = $("#js-ds-address").val();
    var city = $("#js-ds-city").val();
    var state = $("#js-ds-state").val();
    var pincode = $("#js-ds-pin").val();
    var phonenumber = $("#js-ds-phnumbr").val();
    //var selectedDays = $('input[name="locationthemes"]:checked');
    var session1checked = $("#practice-timming").find('input[name="days-checkbox"]:checked');
    var session2checked = $("#practice-timming").find('input[name="days-checkbox2"]:checked');
    var duration = $("#js-duration").val();
    var session1_arr = [];
    var session2_arr = [];

    if (session1checked) {        
        for (var i = 0; i < session1checked.length; i++) {
            var con = session1checked[i];
            session1_arr.push($(con).val());
        }
    }

    if (session2checked) {
        for (var i = 0; i < session2checked.length; i++) {
            var con = session2checked[i];
            session2_arr.push($(con).val());
        }
    }




    var ptvm = {
        address: address,
        city: city,
        state: state,
        pincode: pincode,
        phonenumber: phonenumber,
        duration: duration,
        practicesession: [
            { SessionStartTime: $("#starttime1").val(), SessionEndTime: $("#endtime1").val(), Days: session1_arr },
            { SessionStartTime: $("#starttime2").val(), SessionEndTime: $("#endtime2").val(), Days: session2_arr }
        ]
    }

    $.ajax({
        url: "/doctor/savedoctorpracticeschedule",
        type: "POST",
        data: { ptvm: ptvm },
        success: function (a, b, c) {
            debugger;
            location.href = "/doctor/index";
            $("#js-doctor-partial").on("click", "#js-modal-addPatients", saveNewpatient);
        },
        error: function (a, b, c) {
            debugger;
            $("#js-doctor-partial").on("click", "#js-modal-addPatients", saveNewpatient);
        }
    });
        
}

function addmoreappointments() {
    $("#js-modal-addappointments").modal();
}

function initappointment() {
    $('input[type=radio][name=optpatient]').change(function () {
        debugger;

    });

    //$("#js-modal-addappointments").on("change", ".js-radio-patient", function () {
    //    var patienttype = $(this).attr("data-patienttype");
    //    if (patienttype == "new") {

    //    }
    //    else {

    //    }
    //});
}

function savenewappointments() {
    debugger;
    var datetime = $("#js-app-datetime").val();
    var email = $("#js-app-emailaddress").val();

    var appointmentModel = {
        appointmentType: $('input[name=optradio]:checked').val(),
        firstname: $("#js-app-first-name").val(),
        lastName: $("#js-app-last-name").val(),
        email: $("#js-app-emailaddress").val(),
        beforeopdappointmenttime: $("#js-app-datetime").val()
        //phonenumber: $("#js-phonenumber").val()
    };

    $.ajax({
        url: "/appointments/savenewappointments",
        type: "POST",
        data: { appointmentModel: appointmentModel },
        success: function (a, b, c) {
            debugger;
            location.href = "/doctor/index";
            $("#js-doctor-partial").on("click", "#js-modal-addPatients", saveNewpatient);
        },
        error: function (a, b, c) {
            debugger;
            $("#js-doctor-partial").on("click", "#js-modal-addPatients", saveNewpatient);
        }
    });

}

function doctorschedule() {
    $.ajax({
        url: "/doctor/doctorschedule",
        type: "GET",
        success: function (a, b, c) {

            if (a != null && a != "") {
                $("#js-doctor-partial").html(a)
            }
        },
        error: function (a, b, c) {

        }
    });
}


function doctorappointments() {
    $.ajax({
        url: "/appointments/index",
        type: "GET",
        success: function (a, b, c) {

            if (a != null && a != "") {
                $("#js-doctor-partial").html(a)
            }
        },
        error: function (a, b, c) {

        }
    });
}

function saveNewpatient() {
    $("#js-doctor-partial").off("click", "#js-modal-addPatients", saveNewpatient);
    var patientProfileModel = {
        firstname: $("#js-pat-first-name").val(),
        lastName: $("#js-pat-last-name").val()
        //phonenumber: $("#js-phonenumber").val()
    };

    $.ajax({
        url: "/patient/saveNewpatient",
        type: "POST",
        data: { ppm: patientProfileModel },
        success: function (a, b, c) {
            debugger;
            location.href = "/doctor/index";
            $("#js-doctor-partial").on("click", "#js-modal-addPatients", saveNewpatient);
        },
        error: function (a, b, c) {
            debugger;
            $("#js-doctor-partial").on("click", "#js-modal-addPatients", saveNewpatient);
        }
    });
}


function doctorprofile() {
    $.ajax({
        url: "/doctor/doctorprofile",
        type: "GET",
        success: function (a, b, c) {
            
            if (a != null && a != "") {
                $("#js-doctor-partial").html(a)
            }
        },
        error: function (a, b, c) {

        }
    });
}

function editProfile() {
    $.ajax({
        url: "/doctor/editProfile",
        type: "GET",
        success: function (a, b, c) {
            
            if (a != null && a != "") {
                $("#js-doctor-partial").html(a)
            }
        },
        error: function (a, b, c) {

        }
    });
}

function saveProfile()
{
    var doctorProfileModel = {
        firstname: $("#js-firstname").val(),
        lastName: $("#js-lastname").val(),
        phonenumber: $("#js-phonenumber").val()
    };
    
    $.ajax({
        url: "/doctor/saveProfile",
        type: "POST",
        data: { dpm: doctorProfileModel },
        success: function (a, b, c) {
           
            if (a != null && a != "" && a == "True") {
                location.href = "/doctor/index";
            }
        },
        error: function (a, b, c) {

        }
    });
}

function doctorpatients()
{
    $.ajax({
        url: "/doctor/doctorpatients",
        type: "GET",
        success: function (a, b, c) {

            if (a != null && a != "") {
                $("#js-doctor-partial").html(a)
            }
        },
        error: function (a, b, c) {

        }
    });
}

function addmorepatients() {
    $("#js-modal-addPatients").modal();
}
