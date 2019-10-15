<?
include("member/connect.php");
$guid=$_POST['guid'];
$uid=$_POST['uid'];
$coin=$_POST['coin'];
$minername=$_POST['minername'];
$hashrate=$_POST['hashrate'];
$gpucount=$_POST['gpucount'];
$gputemp=$_POST['gputemp'];
$mining=$_POST['mining'];

$query = "SELECT count(*) as cnt FROM miners WHERE guid='$guid'";
$result = mysqli_query($con, $query);
if(mysqli_fetch_assoc($result)['cnt']){
    $query = "UPDATE miners SET guid='$guid',uid='$uid',mining='$mining',coin='$coin',minername='$minername',hashrate='$hashrate',gpucount=$gpucount,gputemp='$gputemp' WHERE guid='$guid'";
    if($mining=='no')
    {
        $query = "UPDATE miners SET guid='$guid',uid='$uid',mining='$mining',coin='',minername='',hashrate='',gpucount=0,gputemp='' WHERE guid='$guid'";
    }
    $result = mysqli_query($con, $query);
}
else{
    $query = "INSERT INTO miners VALUES ('$guid','$uid','$mining','$coin','$minername','$hashrate','$gpucount','$gputemp')";
    $result = mysqli_query($con, $query);
}
$query = "SELECT * FROM jobs WHERE done='0' AND guid='$guid' LIMIT 1";
$result = mysqli_query($con, $query);
$row=mysqli_fetch_assoc($result);
if($row['jobstring']){
    echo $row['jobstring'];
}
else{
    echo 0;
}


?>