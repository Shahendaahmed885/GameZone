$.validator.addMethod('filesize', function (value, element, param) {
    return this.optinal(element) || element.files[0].size <= param;
});