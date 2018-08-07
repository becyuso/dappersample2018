function SetID(ID,action)
{
    $('#ID').val(ID);
    $('#SubForm').attr('action','/Employee/' + action);
    $('#SubForm').submit();
}