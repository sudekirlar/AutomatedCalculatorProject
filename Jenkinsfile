pipeline {
    agent any

    triggers {
        pollSCM('H/1 * * * *')
    }

    environment {
        PATH = "${tool 'dotnetsdk-6.0'}/bin:${env.PATH}"
    }


    stages {
        stage('Build') {
            steps {
                bat 'dotnet build'
            }
        }

        stage('Test') {
            steps {
                bat 'dotnet test'
            }
        }
    }
}