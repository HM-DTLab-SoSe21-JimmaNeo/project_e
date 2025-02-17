﻿function downloadFile(mimeType, base64String, fileName){
    const fileDataUrl = "data: " + mimeType + ";base64," + base64String;
    fetch(fileDataUrl)
        .then(response => response.blob())
        .then(blob => {

            const link = window.document.createElement("a");
            link.href = window.URL.createObjectURL(blob, { type: mimeType });
            link.download =  fileName;
            
            document.body.appendChild(link);
            link.click();
            document.body.removeChild(link);
            
        });
}