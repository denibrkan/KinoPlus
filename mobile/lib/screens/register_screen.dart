import 'dart:async';
import 'dart:io';
import 'package:flutter/material.dart';
import 'package:mobile/helpers/colors.dart';
import 'package:mobile/helpers/enums.dart';
import 'package:mobile/models/location.dart';
import 'package:mobile/models/register.dart';
import 'package:mobile/providers/location_provider.dart';
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
  late LocationProvider _locationProvider;

  final _formKey = GlobalKey<FormState>();
  final _usernameController = TextEditingController();
  final _passwordController = TextEditingController();
  final _confirmPasswordController = TextEditingController();
  final _firstNameController = TextEditingController();
  final _lastNameController = TextEditingController();
  final _phoneController = TextEditingController();
  final _emailController = TextEditingController();

  Location? selectedLocation;
  List<Location> locations = <Location>[];

  RegistrationSteps _registrationStep = RegistrationSteps.stepOne;
  bool registerInProcess = false;
  File? _imageFile;

  @override
  void initState() {
    super.initState();

    _userProvider = context.read<UserProvider>();
    _locationProvider = context.read<LocationProvider>();

    loadLocations();
  }

  void loadLocations() async {
    var data = await _locationProvider.get(null);

    setState(() {
      locations = data;
    });
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
        locationId: selectedLocation!.id,
      );

      await _userProvider.registerAsync(registerData, _imageFile);

      if (context.mounted) {
        ScaffoldMessenger.of(context).showSnackBar(
          const SnackBar(
              backgroundColor: Colors.lightBlueAccent,
              content: Text('Registracija uspješna.',
                  style: TextStyle(
                    color: Colors.white,
                  ))),
        );
        Navigator.pushNamedAndRemoveUntil(
            context, LoginScreen.routeName, (route) => false);
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
        return _buildUserLocationField();

      case RegistrationSteps.stepTwo:
        return _buildUserCredentialFields();

      case RegistrationSteps.stepThree:
        return _buildUserDetailFields();

      case RegistrationSteps.stepFour:
        return _buildImageField();

      default:
        return Container();
    }
  }

  Widget _buildUserLocationField() {
    return Column(
      children: [
        _buildLocationDropdown(),
        const SizedBox(
          height: 32,
        ),
        Row(
          mainAxisAlignment: MainAxisAlignment.end,
          children: [
            TextButton.icon(
              onPressed: () {
                if (selectedLocation == null) {
                  ScaffoldMessenger.of(context).showSnackBar(
                    const SnackBar(
                        backgroundColor: Colors.redAccent,
                        content: Text(
                          'Odaberite svoje kino...',
                        )),
                  );
                  return;
                }
                setState(() {
                  _registrationStep = RegistrationSteps.stepTwo;
                });
              },
              icon: const Icon(
                Icons.arrow_forward,
              ),
              label: const Text(
                'Dalje',
              ),
            ),
          ],
        ),
      ],
    );
  }

  Widget _buildLocationDropdown() {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Row(
          children: [
            const Icon(
              Icons.location_on_sharp,
              color: Colors.red,
            ),
            const SizedBox(
              width: 5,
            ),
            Text(
              'Kino',
              style: Theme.of(context).textTheme.titleMedium,
            ),
          ],
        ),
        const SizedBox(height: 12),
        locations.isNotEmpty
            ? Container(
                padding: const EdgeInsets.symmetric(horizontal: 8),
                decoration:
                    BoxDecoration(borderRadius: BorderRadius.circular(5)),
                child: DropdownButton<Location>(
                  isExpanded: true,
                  underline: Container(),
                  value: selectedLocation,
                  icon: const Icon(Icons.arrow_drop_down),
                  hint: const Text(
                    'Odaberite svoje kino...',
                    style: TextStyle(color: Colors.grey, fontSize: 15),
                  ),
                  elevation: 16,
                  borderRadius: BorderRadius.circular(5),
                  onChanged: (Location? value) {
                    setState(() {
                      selectedLocation = value;
                    });
                  },
                  items: locations
                      .map<DropdownMenuItem<Location>>(
                          (l) => DropdownMenuItem<Location>(
                                value: l,
                                child: Text('${l.name} - ${l.city.name}'),
                              ))
                      .toList(),
                ),
              )
            : Container(),
      ],
    );
  }

  Widget _buildUserCredentialFields() {
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
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            TextButton.icon(
              onPressed: () =>
                  setState(() => _registrationStep = RegistrationSteps.stepOne),
              icon: const Icon(Icons.arrow_back),
              label: const Text(
                'Nazad',
              ),
            ),
            TextButton.icon(
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
                            content: Text('Korisničko ime se koristi.',
                                style: TextStyle(
                                  color: Colors.white,
                                ))),
                      );
                    }
                  }
                }
              },
              icon: const Icon(
                Icons.arrow_forward,
              ),
              label: const Text(
                'Dalje',
              ),
            ),
          ],
        ),
      ],
    );
  }

  Widget _buildUserDetailFields() {
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
            TextButton.icon(
              onPressed: () =>
                  setState(() => _registrationStep = RegistrationSteps.stepTwo),
              icon: const Icon(Icons.arrow_back),
              label: const Text(
                'Nazad',
              ),
            ),
            TextButton.icon(
              onPressed: () async {
                if (_formKey.currentState!.validate()) {
                  if (await _userProvider
                      .checkUsername(_usernameController.text)) {
                    setState(
                        () => _registrationStep = RegistrationSteps.stepFour);
                  } else {
                    if (mounted) {
                      ScaffoldMessenger.of(context).showSnackBar(
                        const SnackBar(
                            backgroundColor: Colors.redAccent,
                            content: Text(
                              'Korisničko ime se koristi.',
                              style: TextStyle(
                                color: Colors.white,
                              ),
                            )),
                      );
                    }
                  }
                }
              },
              icon: const Icon(
                Icons.arrow_forward,
              ),
              label: const Text(
                'Dalje',
              ),
            ),
          ],
        ),
      ],
    );
  }

  Widget _buildImageField() {
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
        TextButton.icon(
          onPressed: getImageFromGallery,
          icon: const Icon(
            Icons.add_a_photo,
          ),
          label: const Text(
            'Odaberi profilnu sliku',
          ),
        ),
        const SizedBox(height: 32),
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            TextButton.icon(
              onPressed: () => setState(
                  () => _registrationStep = RegistrationSteps.stepThree),
              icon: const Icon(
                Icons.arrow_back,
              ),
              label: const Text(
                'Nazad',
              ),
            ),
            ElevatedButton(
              onPressed: () {
                if (registerInProcess) return;

                if (_formKey.currentState!.validate()) {
                  register();
                }
              },
              style: ElevatedButton.styleFrom(
                  backgroundColor: redButtonColor,
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
