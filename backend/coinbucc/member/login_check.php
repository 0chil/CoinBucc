<?php
session_start(); // 세션
include ("connect.php"); // DB접속

$user_id = $_POST['user_id']; // 아이디
$password = $_POST['password']; // 패스워드
  
$query = "select * from account where user_id='$user_id' and password='$password'";
$result = mysqli_query($con, $query);
$row = mysqli_fetch_array($result);

if($user_id==$row['user_id'] && $password==$row['password']){ // id와 pw가 맞다면 login
   $_SESSION['user_id']=$row['user_id'];
}else{ // id 또는 pw가 다르다면 login 폼으로
   echo "<script>window.alert('invalid username or password');</script>"; // 잘못된 아이디 또는 비빌번호 입니다
}
echo "<script>location.href='../';</script>";

?>