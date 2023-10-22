/**
 * File Upload
 */

'use strict';
    
(function () {
    // previewTemplate: Updated Dropzone default previewTemplate
    // ! Don't change it unless you really know what you are doing
    const previewTemplate = `<div class="dz-preview dz-file-preview">
<div class="dz-details">
  <div class="dz-thumbnail">
    <img data-dz-thumbnail>
    <span class="dz-nopreview">No preview</span>
    <div class="dz-success-mark"></div>
    <div class="dz-error-mark"></div>
    <div class="dz-error-message"><span data-dz-errormessage></span></div>
    <div class="progress">
      <div class="progress-bar progress-bar-primary" role="progressbar" aria-valuemin="0" aria-valuemax="100" data-dz-uploadprogress></div>
    </div>
  </div>
  <div class="dz-filename" data-dz-name></div>
  <div class="dz-size" data-dz-size></div>
</div>
</div>`;

    // Multiple Dropzone
    // --------------------------------------------------------------------
    const dropzoneMulti = document.querySelector('#dropzone-multi');
    
    Dropzone.confirm = function(question, accepted, rejected) {
        $("#dropzone-delete-modal").modal("show");
        
        $(document).on('submit', '.dropzone-form-delete', function (e) {
            e.preventDefault();

            accepted();
            
            $("#dropzone-delete-modal").modal("hide");
            $("#success-modal").modal("show");
        });

    }
    
    if (dropzoneMulti) {
        
        let myDropzone = new Dropzone("#dropzone-multi", {
            previewTemplate: previewTemplate,
            parallelUploads: 1,
            maxFilesize: 5,
            addRemoveLinks: true,
            autoProcessQueue: true,
            dictRemoveFileConfirmation:  $("#RemoveMessageLbl").val(),
            dictRemoveFile: '<i class="fas fa-trash-alt text-white"></i>',
            removedfile: function (file) {
                $.ajax({
                    url: $('#DropzoneLinkToRemove').val(),
                    method: "post",
                    data: {id: file.id},
                    success: function (data) {
                    }
                });

                file.previewTemplate.remove();
            }
        });

        $.ajax({
            url: $('#GetAttachmentLink').val(),
            method: "get",
            success: function (data) {
                //Add existing files into dropzone
                let filesArr = [];

                data.forEach(existingFile => {
                    filesArr.push({
                        id: existingFile.id,
                        name: existingFile.fileName,
                        size: existingFile.fileLength,
                        fullPath: existingFile.fileUrl,
                        fileType: existingFile.fileType
                    });
                });

                filesArr.forEach(existingFile => {
                    let thumbnail = "";

                    if (existingFile.fileType == "image/jpeg" || existingFile.fileType == "image/png" || existingFile.fileType == "image/jpg") {
                        thumbnail = existingFile.fullPath;
                    } else if (existingFile.fileType == "application/pdf") {
                        thumbnail = "/pdf.png";
                    } else if (existingFile.fileType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document" || existingFile.fileType == "application/msword") {
                        thumbnail = "/docx.png";
                    } else if (existingFile.fileType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" || existingFile.fileType == "application/vnd.ms-excel") {
                        thumbnail = "/sheets.png";
                    } else {
                        thumbnail = "/file.png";
                    }

                    myDropzone.emit("addedfile", existingFile);
                    myDropzone.emit("thumbnail", existingFile, thumbnail);
                    myDropzone.emit("complete", existingFile);
                    myDropzone.files.push(existingFile);
                });
            }
        });
    }
})();
