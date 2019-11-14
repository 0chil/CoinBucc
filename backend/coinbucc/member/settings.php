<?php
session_start();
include("connect.php");
if($_SESSION['user_id']==null) {echo "<script>location.href='/'</script>";exit;}

$arr_jobnum_to_eng = array("All done","Poweroff","Rebooted","Updated miner settings","Updated overclock settings");

$query = "SELECT count(*) as cnt FROM miners WHERE uid='$_SESSION[user_id]'";
$result = mysqli_query($con, $query);
$minercnt=mysqli_fetch_assoc($result)['cnt'];

$query = "SELECT count(*) as cnt FROM miners WHERE uid='$_SESSION[user_id]' AND mining='yes'";
$result = mysqli_query($con, $query);
$workingminercnt=mysqli_fetch_assoc($result)['cnt'];

$arr_miner_guid=array();
$query = "SELECT * FROM miners WHERE uid='$_SESSION[user_id]'";
$result = mysqli_query($con, $query);
for($i=0;$row=mysqli_fetch_array($result),$i<$minercnt;$i++){
    $arr_miner_guid[$i]=$row['guid'];
}

function getColorbyTemp($temp){
$tmparr=array(0,45,65,80,100);
$colorarr=array("info","success","warning","danger");
for($i=0;$i<4;$i++){
    if($tmparr[$i]<=$temp && $temp<=$tmparr[$i+1])
        return $colorarr[$i];
}
return "light";
}
?>
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.1.1/css/all.css">