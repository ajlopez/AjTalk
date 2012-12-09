<h1>Customers</h1>
<a href="/">Home</a>
<table>
  <th>
    <td>Id</td>
    <td>Name</td>
  </th>
<# model customers do: [ :customer | #>
<tr>
  <td>${customer id}</td>
  <td>${customer name}</td>
</tr>
<# ]. #>
</table>