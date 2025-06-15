using LINQSamples;

// Create instance of view model
SamplesViewModel vm = new();

// Call Sample Method
var result = vm.UsingWhereAndTake();

// Display Results
vm.Display(result);