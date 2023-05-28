import 'dart:async';
import 'dart:io';
import 'package:flutter/material.dart';
import 'package:mobile/helpers/enums.dart';
import 'package:mobile/models/register.dart';
import 'package:mobile/providers/user_provider.dart';
import 'package:mobile/screens/login_screen.dart';
import 'package:mobile/utils/get_form_input_decoration.dart';
import 'package:mobile/utils/show_error_dialog.dart';
import 'package:provider/provider.dart';
import 'package:image_picker/image_picker.dart';

class RegisterScreen extends StatefulWidget {
  static const routeName = '/register';

  const RegisterScreen({super.key});

  @override
  State<RegisterScreen> createState() => _RegisterScreenState();
}

class _RegisterScreenState extends State<RegisterScreen> {
  late UserProvider _userProvider;

  final _formKey = GlobalKey<FormState>();
  final _usernameController = TextEditingController();
  final _passwordController = TextEditingController();
  final _confirmPasswordController = TextEditingController();
  final _firstNameController = TextEditingController();
  final _lastNameController = TextEditingController();
  final _phoneController = TextEditingController();
  final _emailController = TextEditingController();

  RegistrationSteps _registrationStep = RegistrationSteps.stepOne;
  File? _imageFile;

  @override
  void initState() {
    super.initState();

    _userProvider = context.read<UserProvider>();
  }

  void register() async {
    try {
      var registerData = Register(
        username: _usernameController.text,
        password: _passwordController.text,
        firstName: _firstNameController.text,
        lastName: _lastNameController.text,
        email: _emailController.text,
        phoneNumber: _phoneController.text,
      );

      await _userProvider.registerAsync(registerData, _imageFile);

      if (context.mounted) {
        ScaffoldMessenger.of(context).showSnackBar(
          const SnackBar(
              backgroundColor: Colors.lightBlueAccent,
              content: Text(
                'Registracija uspješna.',
              )),
        );

        Timer(
            const Duration(milliseconds: 1500),
            () => Navigator.pushNamedAndRemoveUntil(
                context, LoginScreen.routeName, (route) => false));
      }
    } on Exception catch (e) {
      showErrorDialog(context, e.toString().substring(11));
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text(
          'Registracija',
          style: TextStyle(fontWeight: FontWeight.normal),
        ),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Form(
          key: _formKey,
          child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [_getRegistrationStep()]),
        ),
      ),
    );
  }

  Widget _getRegistrationStep() {
    switch (_registrationStep) {
      case RegistrationSteps.stepOne:
        return _buildStepOne();

      case RegistrationSteps.stepTwo:
        return _buildStepTwo();

      case RegistrationSteps.stepThree:
        return _buildStepThree();

      default:
        return Container();
    }
  }

  Widget _buildStepOne() {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        TextFormField(
          controller: _usernameController,
          validator: (value) {
            if (value!.isEmpty) {
              return 'Unesite vaše korisničko ime.';
            }
            return null;
          },
          decoration:
              getFormInputDecoration('Korisničko ime', Icons.account_circle),
        ),
        const SizedBox(height: 16),
        TextFormField(
          controller: _passwordController,
          obscureText: true,
          validator: (value) {
            if (value!.isEmpty) {
              return 'Unesite vašu lozinku.';
            }
            return null;
          },
          decoration: getFormInputDecoration('Lozinka', Icons.lock_outline),
        ),
        const SizedBox(height: 16),
        TextFormField(
          controller: _confirmPasswordController,
          obscureText: true,
          validator: (value) {
            if (value!.isEmpty) {
              return 'Potvrdite vašu lozinku.';
            }
            if (value != _passwordController.text) {
              return 'Lozinke se ne podudaraju.';
            }
            return null;
          },
          decoration:
              getFormInputDecoration('Potvrdi lozinku', Icons.lock_reset),
        ),
        const SizedBox(height: 32),
        Row(
          mainAxisAlignment: MainAxisAlignment.end,
          children: [
            ElevatedButton.icon(
              onPressed: () async {
                if (_formKey.currentState!.validate()) {
                  if (await _userProvider
                      .checkUsername(_usernameController.text)) {
                    setState(
                        () => _registrationStep = RegistrationSteps.stepTwo);
                  } else {
                    if (mounted) {
                      ScaffoldMessenger.of(context).showSnackBar(
                        const SnackBar(
                            backgroundColor: Colors.redAccent,
                            content: Text(
                              'Korisničko ime se koristi.',
                            )),
                      );
                    }
                  }
                }
              },
              icon: const Icon(Icons.arrow_forward),
              label: const Text('Dalje'),
            ),
          ],
        ),
      ],
    );
  }

  Widget _buildStepTwo() {
    return Column(
      children: [
        TextFormField(
            controller: _firstNameController,
            autofocus: true,
            validator: (value) {
              if (value!.isEmpty) {
                return 'Unesite vaše ime.';
              }
              return null;
            },
            decoration: getFormInputDecoration('Ime', Icons.account_circle)),
        const SizedBox(height: 16),
        TextFormField(
          controller: _lastNameController,
          validator: (value) {
            if (value!.isEmpty) {
              return 'Unesite vaše prezime';
            }
            return null;
          },
          decoration: getFormInputDecoration('Prezime', Icons.account_circle),
        ),
        const SizedBox(height: 16),
        TextFormField(
            controller: _phoneController,
            decoration: getFormInputDecoration('Broj telefona', Icons.phone)),
        const SizedBox(height: 16),
        TextFormField(
          controller: _emailController,
          validator: (value) {
            if (value!.isEmpty) {
              return 'Unesite vaš email.';
            }
            if (!RegExp(r'^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$').hasMatch(value)) {
              return 'Unesite validan email.';
            }
            return null;
          },
          decoration: getFormInputDecoration('Email', Icons.email),
        ),
        const SizedBox(height: 32),
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            ElevatedButton.icon(
              onPressed: () =>
                  setState(() => _registrationStep = RegistrationSteps.stepOne),
              icon: const Icon(Icons.arrow_back),
              label: const Text('Nazad'),
            ),
            ElevatedButton.icon(
              onPressed: () async {
                if (_formKey.currentState!.validate()) {
                  if (await _userProvider
                      .checkUsername(_usernameController.text)) {
                    setState(
                        () => _registrationStep = RegistrationSteps.stepThree);
                  } else {
                    if (mounted) {
                      ScaffoldMessenger.of(context).showSnackBar(
                        const SnackBar(
                            backgroundColor: Colors.redAccent,
                            content: Text(
                              'Korisničko ime se koristi.',
                            )),
                      );
                    }
                  }
                }
              },
              icon: const Icon(Icons.arrow_forward),
              label: const Text('Dalje'),
            ),
          ],
        ),
      ],
    );
  }

  Widget _buildStepThree() {
    return Column(
      children: [
        _imageFile != null
            ? SizedBox(
                width: 200,
                height: 200,
                child: CircleAvatar(
                  backgroundImage: FileImage(_imageFile!),
                ),
              )
            : Image.asset(
                'assets/images/user-96.png',
                width: 70,
                color: Colors.grey,
              ),
        const SizedBox(
          height: 30,
        ),
        ElevatedButton.icon(
          onPressed: getImageFromGallery,
          icon: const Icon(Icons.add_a_photo),
          label: const Text('Odaberi profilnu sliku'),
        ),
        const SizedBox(height: 32),
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            ElevatedButton.icon(
              onPressed: () =>
                  setState(() => _registrationStep = RegistrationSteps.stepTwo),
              icon: const Icon(Icons.arrow_back),
              label: const Text('Nazad'),
            ),
            ElevatedButton(
              onPressed: () {
                if (_formKey.currentState!.validate()) {
                  register();
                }
              },
              style: ElevatedButton.styleFrom(
                  backgroundColor: const Color(0xFFE51937),
                  padding:
                      const EdgeInsets.symmetric(vertical: 10, horizontal: 25)),
              child: const Text(
                'Završi',
                style: TextStyle(fontSize: 16),
              ),
            )
          ],
        ),
      ],
    );
  }

  Future getImageFromGallery() async {
    var image = await ImagePicker().pickImage(source: ImageSource.gallery);

    setState(() {
      _imageFile = image != null ? File(image.path) : null;
    });
  }
}
