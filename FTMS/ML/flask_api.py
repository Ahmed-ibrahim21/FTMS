from flask import Flask, request, jsonify
import numpy as np
import joblib
from waitress import serve
import os

app = Flask(__name__)

# Load the model
model = joblib.load('calorie_model.pkl')

def calculate_bmi(weight_kg, height_m):
    return weight_kg / (height_m ** 2)

def calculate_bmr(age, weight_kg, height_m, gender):
    if gender == 'F':
        return 655 + (9.6 * weight_kg) + (1.8 * height_m * 100) - (4.7 * age)
    elif gender == 'M':
        return 66 + (13.7 * weight_kg) + (5 * height_m * 100) - (6.8 * age)
    else:
        raise ValueError("Invalid gender value")

@app.route('/predict', methods=['POST'])
def predict():
    try:
        data = request.get_json()
        
        # Validate input
        required_fields = ['age', 'weight', 'height', 'gender', 'activity_level']
        if not all(field in data for field in required_fields):
            return jsonify({'error': 'Missing required fields'}), 400
            
        if data['gender'] not in ['M', 'F']:
            return jsonify({'error': "Gender must be 'M' or 'F'"}), 400
            
        if not (1.2 <= data['activity_level'] <= 1.9):
            return jsonify({'error': 'Activity level must be between 1.2 and 1.9'}), 400
        
        # Calculate features
        bmi = calculate_bmi(data['weight'], data['height'])
        bmr = calculate_bmr(data['age'], data['weight'], data['height'], data['gender'])
        
        # Prepare features for prediction
        gender_F = 1 if data['gender'] == 'F' else 0
        gender_M = 1 if data['gender'] == 'M' else 0
        
        features = np.array([[data['age'], data['weight'], data['height'],
                            bmi, bmr, data['activity_level'],
                            gender_F, gender_M]])
        
        # Make prediction
        predicted_calories = model.predict(features)[0]
        
        # Adjust based on BMI
        if bmi < 18.5:
            predicted_calories += 300
        elif bmi >= 30:
            predicted_calories -= 300
            
        return jsonify({'calories': round(predicted_calories)})
        
    except Exception as e:
        return jsonify({'error': str(e)}), 500

if __name__ == '__main__':
    serve(app, host="0.0.0.0", port=5000)  # ✅ CORRECT - no code after this line