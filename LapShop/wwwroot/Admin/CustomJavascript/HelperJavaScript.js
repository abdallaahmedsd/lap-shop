
function initializeImagePreview() {
    const imageInput = document.querySelector("#image_input");
    const imgElement = document.querySelector("#uploaded_image");

    console.log("image-input:\t", imageInput);
    console.log("img_element:\t", imgElement);

    if (imgElement) {
        // If an existing image is present, remove the required validation
    }

    imageInput.addEventListener("change", function () {
        const reader = new FileReader();
        reader.addEventListener("load", () => {

            imgElement.src = reader.result;
        });
        reader.readAsDataURL(this.files[0]);
    });
}
