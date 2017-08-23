$.validator.methods.range = function (value, element, param) {
    var globalizedValue = value.replace(",", ".");
    return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
}
 
$.validator.methods.number = function (value, element) {
    return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
}
$(document).ready(function(){
        $("#temperature, #pressure").change(function(){
            var temperature = $("#temperature").val();
            var pressure = $("#pressure").val();
            var densityField = $("#density");

            densityField.val(density(temperature,pressure).toString().replace('.', ','));
    });
            $("#temperature").trigger("change");

             $("#targetValueTextBox").dblclick(function(){
                var selectionValue = $("#SelectionType").val();
                if(selectionValue == "0")
                {
                    $("#targetValueModal").modal();
                }
            });
            $("#relativeRoughnessTextBox").dblclick(function(){
                $("#relativeRoughnessModal").modal();
            });

            $(document).ready(function(){
            $('[data-toggle="tooltip"]').tooltip();
});
});
function density (temperature, pressure)
    {
        var t = parseFloat(temperature);
        var p = parseFloat(pressure);
        if(!isNaN(t) && !isNaN(p) && t>=-273.15 && p>=0)
        {
            return (p/(287.05*(t+273.15))).toFixed(4);
        }
    }
function dropDownSubmit()
    {
        $('#mainForm').submit();
        var selectionValue = $("#SelectionType").val();
        var targetValueLabel = $("#TargetValueLabel");

        if(selectionValue == "0")
            targetValueLabel.html("Target value [m<sup>3</sup>/h]");
        else
            targetValueLabel.html("Target value [Pa/m]");
    }