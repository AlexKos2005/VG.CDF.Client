window.SaveAsFile = function (fileName, byteBase64)
{
    var link = window.document.createElement("a");
    link.href = "data:application/octet-stream;base64," + byteBase64;
    link.download = fileName;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}
