<html>
  <head>
    <title>Customers</title>
    <link rel="stylesheet" href="css/bootstrap.css"/>
    <link rel="stylesheet" href="css/docs.css"/>
  </head>
  <body>
    <h1>Customers</h1>
    <a href="/">Home</a>
    <table class='table-striped table-bordered'>
      <tr>
        <th>Id</th>
        <th>Name</th>
      </tr>
      <# model customers do: [ :customer | #>
      <tr>
        <td>${customer id}</td>
        <td>${customer name}</td>
      </tr>
      <# ]. #>
    </table>
  </body>
</html>
