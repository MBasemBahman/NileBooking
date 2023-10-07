var colorClasses = {
    1: "primary",
    2: "seconadry",
    3: "info",
    4: "warning",
    5 : "dark"
};
function hexToRgb(hex) {
    var result = /^#?([a-f\d]{2})([a-f\d]{2})([a-f\d]{2})$/i.exec(hex);
    return result ? {
        r: parseInt(result[1], 16),
        g: parseInt(result[2], 16),
        b: parseInt(result[3], 16)
    } : null;
}


function getRandomColorClass() {
    var num = Math.floor(Math.random() * 5) + 1;
    return colorClasses[num];
}


