# NET_Core_Web_API_Docker_AWS
 A .NET Core Web API in a Docker Container published to AWS

A demo project for creating a basic API that responds "Pong" to a request sent to the mapped api/Ping endpoint

The AWS Infrastructure being used:

AWS Infrastructure
	• ECS Elastic Container Service
		○ Create a Repository
			○ The repository stores built Docker images
		○ Create Cluster
			○ VPC Endpoints
			○ Subnets
			○ Autoscaling group with Linux AMI
		○ Push to repository
			○ Build Image
			○ Tag Image
			○ Push Image
		○ ECS 
			○ Creating Initial task definition
			○ Create service