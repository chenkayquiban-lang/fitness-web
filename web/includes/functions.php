<?php
function e($value) {
    return htmlspecialchars((string)$value, ENT_QUOTES, 'UTF-8');
}

function calculate_bmi($height, $weight) {
    if ($height <= 0) return 0;
    return round($weight / ($height * $height), 2);
}

function bmi_category($bmi) {
    if ($bmi < 18.5) return 'Underweight';
    if ($bmi < 25) return 'Normal weight';
    if ($bmi < 30) return 'Overweight';
    return 'Obese';
}

function bp_status($systolic, $diastolic) {
    if ($systolic < 120 && $diastolic < 80) return 'Normal';
    if ($systolic < 130 && $diastolic < 80) return 'Elevated';
    if (($systolic >= 130 && $systolic <= 139) || ($diastolic >= 80 && $diastolic <= 89)) return 'High blood pressure stage 1';
    if ($systolic >= 140 || $diastolic >= 90) return 'High blood pressure stage 2';
    if ($systolic > 180 || $diastolic > 120) return 'Hypertensive crisis';
    return 'Unclassified';
}

function diet_recommendation($category) {
    switch ($category) {
        case 'Underweight': return 'High-calorie balanced meals with protein, whole grains, healthy fats, and strength training.';
        case 'Normal weight': return 'Maintain balanced meals, regular exercise, hydration, and enough sleep.';
        case 'Overweight': return 'Moderate calorie deficit, more vegetables, lean protein, cardio, and reduced sugary drinks.';
        case 'Obese': return 'Structured weight-loss meal plan, low sugar intake, regular monitoring, and professional guidance.';
        default: return 'Record BMI first to generate a recommendation.';
    }
}
?>

// common functions for the fitness web application, including output escaping, BMI calculation, BMI category determination, blood pressure status evaluation, and diet recommendations based on BMI category. These functions are used across
 various pages to maintain consistency and reduce code duplication.   
 // also added auto-refresh functionality to list pages (members, health records, goals) with a badge indicator, refreshing every 7 seconds if the user is not actively typing in an input field. This ensures that the latest data is displayed without disrupting user input.
 // also updated members list to include edit and delete options, as well as add health option for members
 // updated health add feature with member selection and automatic BMI and blood pressure status calculation based on inputs
 // enhanced the form layout for better user experience in health add page
 // updated goals add feature with member selection and improved form layout
 // updated index page to display latest health records with BMI, blood pressure, and date checked