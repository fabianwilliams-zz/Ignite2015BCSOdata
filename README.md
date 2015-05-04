# Ignite2015BCSOdata
##Fabian Williams DEMO Code##
<h1>MS Ignite Pre Day Hybrid SharePoint BCS Code</h1>

<p>
This is the solution i used to create the OData Feed from my SQL Server which will serve the basis of my EntryPoint for my BCS ECT.
This GitHub Repo has two solutions included in the two folders you see above. The Pubs Folder has the Entity Framework URI and the 
Demo Folder has the SharePoint Project with an External Content Type that is built on OData Feed. 
</p>

##Whats all in here##
<ul>
<li>
SQL Database as External Source utilizing Pubs Database
</li>
<li>
Entity Framework - Database First Model
</li>
<li>
WCF Data Services
</li>
</ul>

##Scenario##
<p>
Using a SQL Database with PUBS data we are going to create a EF Model and use WCF DataServices to 
expose a Odata URI that will be used/consumed as a Exposed API for a External Content Type built in another VS Solution
</p>

