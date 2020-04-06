<?php
$page_title = "Chatfish | Swim Chatfish, swim";
include('header.html');
?>
<link href = "css/home.css" rel = "stylesheet" type = "text/css">
</head>
<body>
<h1>Communication reimagined</h1>
<a id = "chat-button" href = "">Start chatting</a>
<p>
	<?php
	$q = "SELECT COUNT(*) FROM users";
	$r = mysqli_query($dbc, $q);
	echo mysqli_num_rows($r);
	?>
	 users
</p>
</body>
</html>
