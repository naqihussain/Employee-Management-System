<?php
// config/login/config.php
// when setting login_attempt with a numer, that number will be maximum login attempts that a member can do before to show captcha  
// if setting captcha dont need to setting login_attempt

$LOGIN=array(
	'host'=>'localhost',
	'member_200'=>array(
		'login_attempt'=>20,
		'captcha'=>'',
		),
	'member_300'=>array(
		'login_attempt'=>30,
		'captcha'=>''
		)
	);
?>