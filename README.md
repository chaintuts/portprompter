## General
____________

### Author
* Josh McIntyre

### Website
* jmcintyre.net

### Overview
* PortPrompter provides a basic TCP port scanning utility

## Development
________________

### Git Workflow
* master for releases (merge development)
* development for bugfixes and new features

### Building
* Build using Visual Studio for C# version
* For Python version, copy scripts to desired directory

### Features
* Provide IP addresses (one or more) via command line
* The utility will scan common numbers for open ports

### Requirements
* Requires the .NET framework
* Requires Python for the Python version

### Platforms
* Windows
* Linux
* Mac OSX

## Usage
____________

### CLI Usage
* Run `portprompter.exe <ips>` to scan these IP addresses (one or more) for open common ports
* Run `python3 portprompter.py <ips>` for the Python version

### Unit Tests
* Run C# unit tests using Visual Studio Code
* Run Python unit tests with `pytest test_portprompter.py`
