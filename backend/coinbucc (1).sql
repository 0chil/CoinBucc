-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- 생성 시간: 19-12-05 17:26
-- 서버 버전: 10.4.8-MariaDB
-- PHP 버전: 7.3.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- 데이터베이스: `coinbucc`
--

-- --------------------------------------------------------

--
-- 테이블 구조 `account`
--

CREATE TABLE `account` (
  `user_id` varchar(20) NOT NULL,
  `password` text NOT NULL,
  `email` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 테이블의 덤프 데이터 `account`
--

INSERT INTO `account` (`user_id`, `password`, `email`) VALUES
('admin', 'test', 'gorae02@gmail.com');

-- --------------------------------------------------------

--
-- 테이블 구조 `jobs`
--

CREATE TABLE `jobs` (
  `id` int(11) NOT NULL,
  `uid` varchar(20) NOT NULL,
  `guid` varchar(100) NOT NULL,
  `jobstring` varchar(200) NOT NULL,
  `done` int(1) NOT NULL DEFAULT 0,
  `toall` int(11) NOT NULL DEFAULT 0,
  `datetime` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 테이블의 덤프 데이터 `jobs`
--

INSERT INTO `jobs` (`id`, `uid`, `guid`, `jobstring`, `done`, `toall`, `datetime`) VALUES
(1, 'admin', 'c2fb22d1-1dab-48d5-a797-e80d459e684b', '4|||', 1, 0, '2019-11-05 05:04:02'),
(2, 'admin', '28388bf0-df5f-4a0a-9c02-7525357c696b', '4|||', 1, 0, '2019-11-05 05:13:22'),
(3, 'admin', '28388bf0-df5f-4a0a-9c02-7525357c696b', '3|ETP|MK8T36i5ypcKngR47PS8KTKxwgNX5SQNJC|etp-kor1.topmining.co.kr:8008|phoenix', 1, 0, '2019-11-05 05:13:40'),
(4, 'admin', '28388bf0-df5f-4a0a-9c02-7525357c696b', '3|ETP|MK8T36i5ypcKngR47PS8KTKxwgNX5SQNJC|etp-kor1.topmining.co.kr:8008|phoenix', 1, 0, '2019-11-05 05:15:38'),
(5, 'admin', '28388bf0-df5f-4a0a-9c02-7525357c696b', '3|ETP|MK8T36i5ypcKngR47PS8KTKxwgNX5SQNJC|etp-kor1.topmining.co.kr:8008|phoenix', 1, 0, '2019-11-05 05:17:08'),
(6, 'admin', '28388bf0-df5f-4a0a-9c02-7525357c696b', '3|ETP|MK8T36i5ypcKngR47PS8KTKxwgNX5SQNJC|etp-kor1.topmining.co.kr:8008|phoenix', 1, 0, '2019-11-05 05:17:25'),
(7, 'admin', '28388bf0-df5f-4a0a-9c02-7525357c696b', '3|ETP|MK8T36i5ypcKngR47PS8KTKxwgNX5SQNJC|etp-kor1.topmining.co.kr:8008|phoenix', 1, 0, '2019-11-05 05:20:53'),
(8, 'admin', '28388bf0-df5f-4a0a-9c02-7525357c696b', '3|ETP|MK8T36i5ypcKngR47PS8KTKxwgNX5SQNJC|etp-kor1.topmining.co.kr:8008|phoenix', 1, 0, '2019-11-05 05:21:26'),
(9, 'admin', '28388bf0-df5f-4a0a-9c02-7525357c696b', '2', 1, 0, '2019-11-05 05:22:00'),
(10, 'admin', '28388bf0-df5f-4a0a-9c02-7525357c696b', '3|ETP|MK8T36i5ypcKngR47PS8KTKxwgNX5SQNJC|etp-kor1.topmining.co.kr:8008|phoenix', 1, 0, '2019-11-05 05:43:06'),
(11, 'admin', '28388bf0-df5f-4a0a-9c02-7525357c696b', '1', 1, 0, '2019-11-05 06:29:42'),
(12, 'admin', '28388bf0-df5f-4a0a-9c02-7525357c696b', '4|||', 1, 1, '2019-11-05 08:43:02'),
(13, 'admin', 'c2fb22d1-1dab-48d5-a797-e80d459e684b', '4|||', 0, 1, '2019-11-05 08:43:02'),
(14, 'admin', '28388bf0-df5f-4a0a-9c02-7525357c696b', '4|||', 1, 1, '2019-11-05 08:43:03'),
(15, 'admin', 'c2fb22d1-1dab-48d5-a797-e80d459e684b', '4|||', 0, 1, '2019-11-05 08:43:03'),
(16, 'admin', '28388bf0-df5f-4a0a-9c02-7525357c696b', '4|||', 1, 1, '2019-11-05 08:43:05'),
(17, 'admin', 'c2fb22d1-1dab-48d5-a797-e80d459e684b', '4|||', 0, 1, '2019-11-05 08:43:05'),
(18, 'admin', '28388bf0-df5f-4a0a-9c02-7525357c696b', '3|ETP|MK8T36i5ypcKngR47PS8KTKxwgNX5SQNJC|etp-kor1.topmining.co.kr:8008|phoenix', 1, 0, '2019-11-05 16:50:28'),
(19, 'admin', '28388bf0-df5f-4a0a-9c02-7525357c696b', '4|||', 1, 0, '2019-11-05 16:53:23'),
(20, 'admin', '28388bf0-df5f-4a0a-9c02-7525357c696b', '4|||', 1, 0, '2019-11-05 16:53:29'),
(21, 'admin', '28388bf0-df5f-4a0a-9c02-7525357c696b', '3|ETP|MK8T36i5ypcKngR47PS8KTKxwgNX5SQNJC|etp-kor1.topmining.co.kr:8008|phoenix', 1, 0, '2019-11-05 18:49:56'),
(22, 'admin', '28388bf0-df5f-4a0a-9c02-7525357c696b', '1', 1, 0, '2019-11-05 19:20:01');

-- --------------------------------------------------------

--
-- 테이블 구조 `miners`
--

CREATE TABLE `miners` (
  `guid` varchar(50) NOT NULL,
  `uid` varchar(50) NOT NULL,
  `mining` varchar(5) NOT NULL,
  `coin` varchar(10) NOT NULL,
  `minername` varchar(50) NOT NULL,
  `hashrate` varchar(10) NOT NULL,
  `gpucount` int(11) NOT NULL,
  `gputemp` varchar(50) NOT NULL,
  `gpuelec` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 테이블의 덤프 데이터 `miners`
--

INSERT INTO `miners` (`guid`, `uid`, `mining`, `coin`, `minername`, `hashrate`, `gpucount`, `gputemp`, `gpuelec`) VALUES
('28388bf0-df5f-4a0a-9c02-7525357c696b', 'admin', 'no', '', '', '', 0, '', 445),
('c2fb22d1-1dab-48d5-a797-e80d459e684b', 'admin', 'no', '', '', '', 0, '', 0);

--
-- 덤프된 테이블의 인덱스
--

--
-- 테이블의 인덱스 `account`
--
ALTER TABLE `account`
  ADD PRIMARY KEY (`user_id`);

--
-- 테이블의 인덱스 `jobs`
--
ALTER TABLE `jobs`
  ADD PRIMARY KEY (`id`);

--
-- 테이블의 인덱스 `miners`
--
ALTER TABLE `miners`
  ADD PRIMARY KEY (`guid`);

--
-- 덤프된 테이블의 AUTO_INCREMENT
--

--
-- 테이블의 AUTO_INCREMENT `jobs`
--
ALTER TABLE `jobs`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
