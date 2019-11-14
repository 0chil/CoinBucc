<?php
include("member/connect.php");
$guid=$_POST['guid'];
$uid=$_POST['uid'];
$coin=$_POST['coin'];
$minername=$_POST['minername'];
$hashrate=$_POST['hashrate'];
$gpucount=$_POST['gpucount'];
$gputemp=$_POST['gputemp'];
$gpuelec=$_POST['gpuelec'];
$mining=$_POST['mining'];

$query = "SELECT count(*) as cnt FROM miners WHERE guid='$guid'";
$result = mysqli_query($con, $query);
if(mysqli_fetch_assoc($result)['cnt']){
    $query = "UPDATE miners SET guid='$guid',uid='$uid',mining='$mining',coin='$coin',minername='$minername',hashrate='$hashrate',gpucount=$gpucount,gputemp='$gputemp',gpuelec='$gpuelec' WHERE guid='$guid'";
    if($mining=='no')
    {
        $query = "UPDATE miners SET guid='$guid',uid='$uid',mining='$mining',coin='',minername='',hashrate='',gpucount=0,gputemp='' WHERE guid='$guid'";
    }
    $result = mysqli_query($con, $query);
}
else{
    $query = "INSERT INTO miners VALUES ('$guid','$uid','$mining','$coin','$minername','$hashrate','$gpucount','$gputemp','$gpuelec')";
    $result = mysqli_query($con, $query);
}
$query = "SELECT * FROM jobs WHERE done='0' AND guid='$guid' LIMIT 1";
$result = mysqli_query($con, $query);
$row=mysqli_fetch_assoc($result);
if($row['jobstring']){
    $jobcode=substr($row['jobstring'],0,1);
    if($jobcode=='3' || $jobcode=='4'){
        //채굴기 종료시 작업상황 초기화
        $query = "UPDATE miners SET guid='$guid',uid='$uid',mining='no',coin='',minername='',hashrate='',gpucount=0,gputemp='' WHERE guid='$guid'";
        $result = mysqli_query($con, $query);
    }
    echo $row['jobstring'];
}
else{
    echo 0;
}


?>