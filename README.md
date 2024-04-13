# Ludum Dare template

Template for Ludum Dare projects.

* Builds on push.
* Uploads to itch.io.

## Usage

1. Possibly update .github/workflows/unity-ci-for-ludum.yml:unityVersion
2. Add secrets to GitHub
Find Unity license file:
    Windows: C:\ProgramData\Unity\Unity_lic.ulf
    Mac: /Library/Application Support/Unity/Unity_lic.ulf
    Linux: ~/.local/share/unity3d/Unity/Unity_lic.ulf
Create the following secrets: Settings -> Secrets and variables -> Actions -> New repository secret
    UNITY_LICENSE - (Copy the contents of your license file into here)
    UNITY_EMAIL - (Add the email address that you use to login to Unity)
    UNITY_PASSWORD - (Add the password that you use to login to Unity)
3. Add itch.io secret:
    Create a new API key at <https://itch.io/user/settings/api-keys>
    Create a new secret in the repository called BUTLER_CREDENTIALS
Update Deploy step. Change ITCH_GAME
