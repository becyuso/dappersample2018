function SetID(ID,action)
{
    debugger;
    $('#ID').val(ID);
    $('#SubForm').attr('action','/Employee/' + action);
    $('#SubForm').submit();
}