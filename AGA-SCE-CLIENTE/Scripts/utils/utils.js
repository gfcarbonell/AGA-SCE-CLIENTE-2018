function formatDateTimeCSharpToJavascript(date, format = true) {
    if (format === true) {
        let jsonDate = date;  // returns "/Date(1245398693390)/";
        let re = /-?\d+/;
        let m = re.exec(jsonDate);
        let d = new Date(parseInt(m[0]));
        let day = ("0" + d.getDate()).slice(-2);
        let year = d.getFullYear();
        let month = ("0" + (d.getMonth() + 1)).slice(-2);
        let hour = (d.getHours());
        let min = (d.getMinutes());
        let sec = (d.getMilliseconds());
        hour = hour.toString().length >= 2 ? hour : "0" + hour;
        min = min.toString().length >= 2 ? min : "0" + min;
        sec = min.toString().length >= 2 ? min : "0" + min;
        let today = `${day}/${month}/${year}T${hour}:${min}:${sec}`
        return today
    }
    else {
        let jsonDate = date;  // returns "/Date(1245398693390)/";
        let re = /-?\d+/;
        let m = re.exec(jsonDate);
        let d = new Date(parseInt(m[0]));
        let day = ("0" + d.getDate()).slice(-2);
        let year = d.getFullYear();
        let month = ("0" + (d.getMonth() + 1)).slice(-2);
        let hour = ("0" + d.getHours()) | "00";
        let min = ("0" + d.getMinutes()) | "00";
        let sec = ("0" + d.getMilliseconds()) | "00";
        hour = hour.toString().length >= 2 ? hour : "0" + hour;
        min = min.toString().length >= 2 ? min : "0" + min;
        sec = min.toString().length >= 2 ? min : "0" + min;
        let today = `${year}/${month}/${day}T${hour}:${min}:${sec}`
        return today;
    }
}

function changeDateSimbol(date, simbol = "/") {
    var now = new Date(date);
    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    var today = now.getFullYear() + simbol + (month) + simbol + (day);
    return today;
}

function zfill(number, width) {
    var numberOutput = Math.abs(number); /* Valor absoluto del número */
    var length = number.toString().length; /* Largo del número */
    var zero = "0"; /* String de cero */

    if (width <= length) {
        if (number < 0) {
            return ("-" + numberOutput.toString());
        } else {
            return numberOutput.toString();
        }
    } else {
        if (number < 0) {
            return ("-" + (zero.repeat(width - length)) + numberOutput.toString());
        } else {
            return ((zero.repeat(width - length)) + numberOutput.toString());
        }
    }
}
