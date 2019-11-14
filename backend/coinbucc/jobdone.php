<?php
include("member/connect.php");
$guid=$_GET['guid'];

$query = "UPDATE jobs SET done='1' WHERE done='0' AND guid='$guid' LIMIT 1";
$result = mysqli_query($con, $query);
?>