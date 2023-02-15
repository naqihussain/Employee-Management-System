function DisplayImage(input) {
    $(".imagediv").show();
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#displayimage')
                .attr('src', e.target.result);
        };  
        reader.readAsDataURL(input.files[0]);
    }
}
function DisplayProductImage(input) {
    alert();
    //$(".productimagediv").show();
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#displayproductimage')
                .attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}