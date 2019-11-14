<?php
include("member/settings.php");
$jobstring=$_GET['job'];
$guid=$_GET['guid'];
$user_id=$_SESSION['user_id'];
$toall=$_GET['toall'];

date_default_timezone_set('Asia/Seoul');
$date=date('Y-m-d H:i:s');
if(!$toall){
    $query = "INSERT INTO jobs VALUES('','$user_id','$guid','$jobstring','','','$date')";
    $result = mysqli_query($con, $query);
    echo "<script>location.href='minermanage.php?guid=$guid'</script>";
}
else{
    for($i=0;$i<$minercnt;$i++){
        $query = "INSERT INTO jobs VALUES('','$user_id','$arr_miner_guid[$i]','$jobstring','','1','$date')";
        $result = mysqli_query($con, $query);
    }
    echo "<script>location.href='minermanageall.php'</script>";
}
?>
