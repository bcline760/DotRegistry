export interface GithubProfile {
  /**
   * URL of the account's avatar.
   * */
  avatarUrl: string;

  /**
   * The account's biography
   * */
  bio: string | null;

  /**
  * The GitHub user's company if they have one
  * */
  company: string | null;

  /**
  * Their e-mail address
  * */
  email: string;

  /**
  * The HTML URL for the account on github.com (or GitHub Enterprise).
  * */
  htmlUrl: string;

  /**
   * The account's login. This 
   * */
  login: string;

  /**
  *  The account's login.
  * */
  location: string;

  /**
  * Modules published by this user
  * */
  modules: string[] | null;

  /**
  * The GitHub user's name
  * */
  name: string;

  /**
  * GraphQL Node Id
  * */
  nodeId: string;

  /**
  * Providers published by the user
  * */
  providers: string[] | null;

  /**
  * The account's API URL.
  * */
  url: string;
}
