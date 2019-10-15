<?
include ("connect.php");
$user_id=$_POST['user_id'];
$password=$_POST['password'];
$email=$_POST['email'];

$query = "INSERT INTO account VALUES('$user_id','$password','$email')";
$result = mysqli_query($con, $query);
$row = mysqli_fetch_array($result);

echo "<script>location.href='../login.php';</script>";
?>