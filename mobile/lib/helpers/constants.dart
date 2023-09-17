const apiUrl = String.fromEnvironment('baseUrl',
    defaultValue: 'https://10.0.2.2:44396/api');
const stripePublishKey = String.fromEnvironment('stripePublishKey',
    defaultValue:
        'pk_test_51NOzWMGBVAwWZNvSVMrbvWXgTwnz4QT93dLrEProXjit9ZPW5HSj0vOFAJRZlZk5Vg0DBj9PAQejNQhrNjmXV0on00DRXfJP7u');
const stripeSecretKey = String.fromEnvironment('stripeSecretKey',
    defaultValue:
        'sk_test_51NOzWMGBVAwWZNvSfhLrYaGxvxo472RAmLg36Z1d7mJ6qGI5ErBK68LtnMFBDWrhusbrfzYqRxvkHmrvCxQUrKj100AMxfaBRu');
const appTitle = 'Kino+';
