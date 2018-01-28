var cvUploadFile = '';
var pageIndex=0;
var fistTime=0;
var totalCount= "<%=totalCount%>";
 var done=false;
  
     function fileValidation(FileID) {
         if ($('#' + FileID).val() == '') {
             alert("No File Choosen.");
             return false;
         }
         var ext = $('#' + FileID).val().match(/\.(.+)$/)[1];
         switch (ext.toLowerCase()) {
             case 'doc':
             case 'docx':
             case 'rtf':
             case 'pdf':
             case 'gif':
                 $('#buttonUpload').attr('disabled', false); $('#buttonUploadLogo').attr('disabled', false);
                 break;
             default:
                 $('#' + FileID).val('');
                 alert('This is not an allowed file type.');
                 return false;
         }
         return true;
     }

     function CoachingDTO() {
        var Id;
        var Name;     
        var Phone;        
        var email;    
        var CategoryName;    
        var CVPath;
     }

     function Save() {
         var coachingDTO = new CoachingDTO();
         coachingDTO.Id = $("#hdnCoachingId").val();
         coachingDTO.Name = $("#txtCname").val();         
         coachingDTO.Phone = $("#txtCphone").val();
         coachingDTO.email = $("#txtCemail").val();

         coachingDTO.CategoryName = $("#ctl00_MainContent_drpCategory option:selected").html();
         coachingDTO.CVPath = $("#ContentPlaceHolder1_hdnCV").val();
           

              
         if (coachingDTO.Name == '') {
             alert("Please enter name");
             $("#txtCname").focus();
             return false;
         }
         else if (coachingDTO.Phone == '') {
             alert("Please enter contact number");
             $("#txtCphone").focus();
             return false;
         }
         else if (coachingDTO.Phone.length != 10) {
             alert("Please enter 10 digits contact number");
             $("#txtCphone").focus();
             return false;
         }
         else if (coachingDTO.email == '') {
             alert("Please enter email address");
             $("#txtCemail").focus();
             return false;
         }
         else if ($("#ctl00_MainContent_drpCategory").val() == '0') {
             alert("Please select role");
             $("#ctl00_MainContent_drpCategory").focus();
             return false;
         }

         else if ($("#ContentPlaceHolder1_hdnCV").val() == '') 
         {
             alert("Please upload CV");
             //$("#txtCemail").focus();
             return false;
         }
         

//         //Check Terms & Conditions         
//         if ($("#hdnCoachingId").val()=="0" && !$('#chkAgree').attr('checked')) {
//             alert("Please accept Terms & Conditions");
//             return false;
//         }


//         $("#ImgProgress img").css("margin-top", "2px");

//         $("#ImgProgress").height("600px").show();

         $.ajax
                  ({
                      type: "POST",
                      url: "KompServices.asmx/SaveJob",
                      data: "{jobPostDTO: " + JSON.stringify(coachingDTO) + "}",
                      contentType: "application/json",
                      dataType: "json",
                      success: function (data) {
                          if (data.d == 99999999) {
                              alert('Your session is expired. Please login again');
                              window.location.href = "Default.aspx";
                              return false;
                          }
                          else {
                              //$("#ImgProgress,#imgFree,#imgPostHeader").hide();
                              alert('You have successfully sent a request.');
                              $("#ContentPlaceHolder1_hdnCV").val('');
                              $("#ContentPlaceHolder1_lblCVName").val('');                              
                              window.location.href = "Default.aspx";
                              return false;
                          }
                      },
                      error: function (res) { alert(res.status + ' ' + res.statusText); }
                  });

              }


            