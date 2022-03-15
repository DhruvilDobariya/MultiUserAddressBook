var loadFile = function (event) {
	var image = document.getElementById('imgImage');
	image.src = URL.createObjectURL(event.target.files[0]);
};

function uploadImage() {
    $('#MainContent_UploadButton').click()
}
function selectFile() {
    $('#MainContent_FileUploadControl').click();
}