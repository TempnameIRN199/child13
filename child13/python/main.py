from g4f.client import Client

text = ""
with open('data/text/text.txt', 'r') as file:
    text = file.read()

client = Client()
response = client.chat.completions.create(
    model="gpt-3.5-turbo",
    messages=[{"role": "system", "content": "Youre a translator to Ukrainian. Traslate the text from English to Ukrainian. Simply transfer, without any extra"},
    {"role": "user", "content": text}]
)
print(response.choices[0].message.content)